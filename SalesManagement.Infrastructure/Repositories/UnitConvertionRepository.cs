using SalesManagement.Core.Models;
using SalesManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Infrastructure.Repositories
{
    internal class UnitConvertionRepository:GenericRepository<UnitConvertion>,IUnitConversionRepository
    {
        private readonly DbContextClass db;
        public UnitConvertionRepository(DbContextClass dbContext) : base(dbContext)
        {
            this.db = dbContext;

         
        }
      public  System.Object GetUnitConvertions()
        {

            //var unitConvertion = await unitConvertionService.GetAllUnitConvertions();
            //if (unitConvertion == null)
            //{
            //    return NotFound();
            //}
            //  return Ok(unitConvertion);


            var unitAndConvertion = from a in db.UnitConvertions
                                    join b in db.Units
                                    on a.UnitId equals b.UnitId
                                    join c in db.Products
                                    on a.ProductId equals c.ProductId
                                    select new
                                    {
                                        a.UnitConvertionId,
                                        b.UnitId,
                                        b.UnitName,
                                        c.ProductId,
                                        c.ProductName,
                                        a.Quantity
                                    };

            return unitAndConvertion;
        }
    }
}
