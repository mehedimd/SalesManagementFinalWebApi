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
    public class PharmaciesController : ControllerBase
    {
        private readonly IPharmacyService pharmacyService;

        public PharmaciesController(IPharmacyService context)
        {
            pharmacyService = context;
        }

        // GET: api/Pharmacies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pharmacy>>> GetPharmacies()
        {
            var pharmacys = await pharmacyService.GetAllPharmacys();
          if (pharmacys == null)
          {
              return NotFound();
          }
            return Ok(pharmacys);
        }

        // GET: api/Pharmacies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pharmacy>> GetPharmacy(int id)
        {
            var pharmacy = await pharmacyService.GetPharmacyById(id);

            if (pharmacy == null)
            {
                return NotFound();
            }

            return pharmacy;
        }

        // PUT: api/Pharmacies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPharmacy(int id, Pharmacy pharmacy)
        {
            if (id != pharmacy.PharmacyId)
            {
                return BadRequest();
            }

            if(pharmacy != null)
            {
                var isUpdated = await pharmacyService.UpdatePharmacy(pharmacy);
                if (isUpdated)
                {
                    return Ok(isUpdated);
                }
            }
            return BadRequest();
        }

        // POST: api/Pharmacies
        [HttpPost]
        public async Task<ActionResult<Pharmacy>> PostPharmacy(Pharmacy pharmacy)
        {
            if (pharmacy != null)
            {
                var isCreated = await pharmacyService.CreatePharmacy(pharmacy);
                if (isCreated)
                {
                    return Ok(isCreated);
                }
            }
            return BadRequest();
        }

        // DELETE: api/Pharmacies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePharmacy(int id)
        {

            var isDeleted = await pharmacyService.DeletePharmacy(id);
            if (isDeleted)
            {
                return Ok(isDeleted);
            }

            return BadRequest();
        }

    }
}
