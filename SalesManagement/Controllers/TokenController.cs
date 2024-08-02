using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SalesManagement.Core.Interfaces;
using SalesManagement.Core.Models;
using SalesManagement.Infrastructure;

namespace SalesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly DbContextClass dbContext;
        private readonly ITokenService tokenService;
        private readonly UserManager<ApplicationUser> userManager;

        public TokenController(DbContextClass db, ITokenService _tokenService, UserManager<ApplicationUser> _userManager)
        {
            this.dbContext = db;
            this.tokenService = _tokenService;
            this.userManager = _userManager;
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh(TokenApiModel tokenApiModel)
        {
            if (tokenApiModel == null)
            {
                return BadRequest("Invalid client request");
            }
            string accessToken = tokenApiModel.AccessToken;
            string refreshToken = tokenApiModel.RefreshToken;

            var principal = tokenService.GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity.Name;

            var user = dbContext.Users.FirstOrDefault(u => u.UserName == username);

            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return BadRequest("Invalid client request");
            }
            var role = userManager.GetRolesAsync(user).Result.FirstOrDefault();
            var newAccessToken = tokenService.GenerateAccessToken(principal.Claims);
            var newRefreshToken = tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            dbContext.SaveChanges();
            

            return Ok(new AuthenticatedResponse()
            {
                Token = newAccessToken,
                RefreshToken = newRefreshToken,
                Role = role,
                applicationUser = user,
            });
        }
        [HttpPost, Authorize]
        [Route("revoke")]
        public IActionResult Revoke()
        {
            var username = User.Identity.Name;

            var user = dbContext.Users.SingleOrDefault(u => u.UserName == username);
            if (user == null) return BadRequest();
            user.RefreshToken = null;
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}
