using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SalesManagement.Core.Models;
using SalesManagement.Infrastructure;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;

namespace SalesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private UserManager<ApplicationUser> userManager;
        private DbContextClass db;
        public AuthController(UserManager<ApplicationUser> _userManager, DbContextClass _db)
        {
            this.userManager = _userManager;
            this.db = _db;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel user)
        {
            var existUser = await userManager.FindByEmailAsync(user.Email);
            if (existUser != null)
            {
                return BadRequest(new {error = "This User Already Exists" });
            }
            var newUser = new ApplicationUser()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.Email,
                Email = user.Email,

            };
            var result = await userManager.CreateAsync(newUser, user.Password);
            if (result.Succeeded)
            {
                return Ok(user);
            }
            return BadRequest();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel user)
        {
            if (user == null)
            {
                return BadRequest(new {error = "Invalid Client Request" });
            }
            else
            {
                var existUser = await userManager.FindByEmailAsync(user.UserName);
                if (existUser == null)
                {
                    return Unauthorized(new { error = "invalid username" });
                }
                else
                {
                    var checkPass = await userManager.CheckPasswordAsync(existUser, user.Password);
                    if (checkPass)
                    {
                            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345superSecretKey@345"));
                            var signinCredential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                            var tokenOption = new JwtSecurityToken
                                (
                                    issuer: "https://localhost:7140",
                                    audience: "https://localhost:7140",
                                    claims: new List<Claim>(),
                                    expires: DateTime.Now.AddMinutes(30),
                                    signingCredentials: signinCredential
                                );
                            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOption);
                            return Ok(new AuthenticatedResponse { Token = tokenString });
                    }
                    else
                    {
                        return Unauthorized(new { error = "invalid password" });
                    }
                }
                
                
            }
            return Unauthorized(new {error = "Invalid username or password" });
        }
    }
}
