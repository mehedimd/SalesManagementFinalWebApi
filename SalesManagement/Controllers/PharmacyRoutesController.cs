using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesManagement.Core.Models;
using SalesManagement.Infrastructure;

namespace SalesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyRoutesController : ControllerBase
    {
        private readonly DbContextClass _context;

        public PharmacyRoutesController(DbContextClass context)
        {
            _context = context;
        }

        // GET: api/PharmacyRoutes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PharmacyRoute>>> GetPharmacyRoute()
        {
          if (_context.PharmacyRoute == null)
          {
              return NotFound();
          }
            return await _context.PharmacyRoute.ToListAsync();
        }

        // GET: api/PharmacyRoutes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PharmacyRoute>> GetPharmacyRoute(int id)
        {
          if (_context.PharmacyRoute == null)
          {
              return NotFound();
          }
            var pharmacyRoute = await _context.PharmacyRoute.FindAsync(id);

            if (pharmacyRoute == null)
            {
                return NotFound();
            }

            return pharmacyRoute;
        }

        // PUT: api/PharmacyRoutes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPharmacyRoute(int id, PharmacyRoute pharmacyRoute)
        {
            if (id != pharmacyRoute.Id)
            {
                return BadRequest();
            }

            _context.Entry(pharmacyRoute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PharmacyRouteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PharmacyRoutes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PharmacyRoute>> PostPharmacyRoute(PharmacyRoute pharmacyRoute)
        {
          if (_context.PharmacyRoute == null)
          {
              return Problem("Entity set 'DbContextClass.PharmacyRoute'  is null.");
          }
            _context.PharmacyRoute.Add(pharmacyRoute);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPharmacyRoute", new { id = pharmacyRoute.Id }, pharmacyRoute);
        }

        // DELETE: api/PharmacyRoutes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePharmacyRoute(int id)
        {
            if (_context.PharmacyRoute == null)
            {
                return NotFound();
            }
            var pharmacyRoute = await _context.PharmacyRoute.FindAsync(id);
            if (pharmacyRoute == null)
            {
                return NotFound();
            }

            _context.PharmacyRoute.Remove(pharmacyRoute);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PharmacyRouteExists(int id)
        {
            return (_context.PharmacyRoute?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
