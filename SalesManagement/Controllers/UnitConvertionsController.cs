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
    public class UnitConvertionsController : ControllerBase
    {
        private readonly IUnitConvertionService unitConvertionService;
   

        public UnitConvertionsController(IUnitConvertionService context, DbContextClass _db)
        {
            unitConvertionService = context;
             
        }

        // GET: api/UnitConvertions
        [HttpGet]
        public System.Object GetUnitConvertions()
        {
            return this.unitConvertionService.GetUnitConvertions();

          //var unitConvertion = await unitConvertionService.GetAllUnitConvertions();
          //if (unitConvertion == null)
          //{
          //    return NotFound();
          //}
          //  return Ok(unitConvertion);


            //var unitAndConvertion = from a in db.UnitConvertions
            //                        join b in db.Units
            //                        on a.UnitId equals b.UnitId
            //                        join c in db.Products
            //                        on a.ProductId equals c.ProductId
            //                        select new
            //                        {
            //                            a.UnitConvertionId,
            //                            b.UnitId,
            //                            b.UnitName,
            //                            c.ProductId,
            //                            c.ProductName,
            //                            a.Quantity
            //                        };

            //    return Ok(unitAndConvertion);\

        }

        // GET: api/UnitConvertions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnitConvertion>> GetUnitConvertion(int id)
        {
            var unitConvertion = await unitConvertionService.GetUnitConvertionById(id);

            if (unitConvertion == null)
            {
                return NotFound();
            }

            return unitConvertion;
        }

        // PUT: api/UnitConvertions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnitConvertion(int id, UnitConvertion unitConvertion)
        {
            if (id != unitConvertion.UnitConvertionId)
            {
                return BadRequest();
            }
            if(unitConvertion != null)
            {
                var isUpdated = await unitConvertionService.UpdateUnitConvertion(unitConvertion);

                if (isUpdated)
                {
                    return Ok(isUpdated);
                }
            }

            return BadRequest();
        }

        // POST: api/UnitConvertions
        [HttpPost]
        public async Task<ActionResult<UnitConvertion>> PostUnitConvertion(UnitConvertion unitConvertion)
        {
            if (unitConvertion != null)
            {
                var isCreated = await unitConvertionService.CreateUnitConvertion(unitConvertion);

                if (isCreated)
                {
                    return Ok(isCreated);
                }
            }

            return BadRequest();
        }

        // DELETE: api/UnitConvertions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnitConvertion(int id)
        {
            var isDeleted = await unitConvertionService.DeleteUnitConvertion(id);
            if (isDeleted)
            {
                return Ok(isDeleted);
            }
            return BadRequest();
        }

    }
}
