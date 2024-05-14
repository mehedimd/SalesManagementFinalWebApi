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
    public class SalesTargetsController : ControllerBase
    {
        private readonly ISalesTargetService salesTargetService;

        public SalesTargetsController(ISalesTargetService context)
        {
            salesTargetService = context;
        }

        // GET: api/SalesTargets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesTarget>>> GetSalesTargets()
        {
            var allTargets = await salesTargetService.GetAllSalesTargets();
            if (allTargets != null)
            {
                return Ok(allTargets);
            }
            return NotFound("No Target found");
        }

        // GET: api/SalesTargets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesTarget>> GetSalesTarget(int id)
        {
            var target = await salesTargetService.GetSalesTargetById(id);
            if (target != null)
            {
                return Ok(target);
            }
            return NotFound("Target is not available");
        }

        // PUT: api/SalesTargets/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesTarget(SalesTarget salesTarget)
        {
            if (salesTarget != null)
            {
                var isUpdated = await salesTargetService.UpdateSalesTarget(salesTarget);
                if (isUpdated)
                {
                    return Ok(isUpdated);
                }
                return BadRequest();
            }
            return BadRequest();
        }

        // POST: api/SalesTargets

        [HttpPost]
        public async Task<ActionResult<SalesTarget>> PostSalesTarget(SalesTarget salesTarget)
        {
            var isCreated = await salesTargetService.CreateSalesTarget(salesTarget);
            if (isCreated)
            {
                return Ok(isCreated);
            }
            return BadRequest("Not created");
        }

        // DELETE: api/SalesTargets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesTarget(int id)
        {
            var isDeleted = await salesTargetService.DeleteSalesTarget(id);
            if (isDeleted)
            {
                return Ok("Delete successful");
            }
            return BadRequest();
        }
    }
}
