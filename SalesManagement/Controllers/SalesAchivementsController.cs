using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesManagement.Core.Models;
using SalesManagement.Infrastructure;
using SalesManagement.Services.Interfaces;

namespace SalesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesAchivementsController : ControllerBase
    {
        private readonly ISalesAchivementService salesAchivementService;

        public SalesAchivementsController(ISalesAchivementService context)
        {
            salesAchivementService = context;
        }

        // GET: api/SalesAchivements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesAchivement>>> GetSalesAchivements()
        {
            var allAchievement = await salesAchivementService.GetAllSalesAchivements();
            if (allAchievement != null)
            {
                return Ok(allAchievement);
            }
            return NotFound("No Achievement Found");
        }

        // GET: api/SalesAchivements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesAchivement>> GetSalesAchivement(int id)
        {
            var achievement = await salesAchivementService.GetSalesAchivementById(id);
            if (achievement != null)
            {
                return Ok(achievement);
            }
            return NotFound("No achievement found");
        }

        // PUT: api/SalesAchivements/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesAchivement(SalesAchivement salesAchivement)
        {
            var isUpdated = await salesAchivementService.UpdateSalesAchivement(salesAchivement);
            if (isUpdated)
            {
                return Ok(isUpdated);
            }
            return BadRequest(!isUpdated);
        }

        // POST: api/SalesAchivements
        [HttpPost]
        public async Task<ActionResult<SalesAchivement>> PostSalesAchivement(SalesAchivement salesAchivement)
        {
            var isCreated = await salesAchivementService.CreateSalesAchivement(salesAchivement);
            if (isCreated)
            {
                return Ok("Created Successfully");
            }
            return BadRequest("Creation Failld");
        }

        // DELETE: api/SalesAchivements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesAchivement(int id)
        {
            var isDeleted = await salesAchivementService.DeleteSalesAchivement(id);
            if (isDeleted)
            {
                return Ok("Deleted Successfully");
            }
            return BadRequest("Delete Failled");
        }
    }
}
