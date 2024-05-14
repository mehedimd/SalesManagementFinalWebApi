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
    public class UnitsController : ControllerBase
    {
        private readonly IUnitService unitService;

        public UnitsController(IUnitService context)
        {
            unitService = context;
        }

        // GET: api/Units
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Unit>>> GetUnits()
        {
          var allUnits = await unitService.GetAllUnits();
          if (allUnits == null)
          {
              return NotFound();
          }
            return Ok(allUnits);
        }

        // GET: api/Units/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Unit>> GetUnit(int id)
        {
            var unit = await unitService.GetUnitById(id);

            if (unit != null)
            {
                return Ok(unit);
            }

            return BadRequest();
        }

        // PUT: api/Units/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnit(int id, Unit unit)
        {
            if (id != unit.UnitId)
            {
                return BadRequest();
            }

            var isUpdated = await unitService.UpdateUnit(unit);

            if(isUpdated)
            {
                return Ok(isUpdated);
            }

            return BadRequest();
        }

        // POST: api/Units

        [HttpPost]
        public async Task<ActionResult<Unit>> PostUnit(Unit unit)
        {
          var isCreated = await unitService.CreateUnit(unit);
            if (isCreated)
            {
                return Ok(isCreated);
            }
            return BadRequest();
        }

        // DELETE: api/Units/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnit(int id)
        {
            var isDeleted = await unitService.DeleteUnit(id);
            if (isDeleted)
            {
                return Ok(isDeleted);
            }
            return BadRequest();
        }


    }
}
