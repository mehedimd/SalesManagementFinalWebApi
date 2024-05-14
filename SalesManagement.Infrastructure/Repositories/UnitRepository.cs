using SalesManagement.Core.Models;
using SalesManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Infrastructure.Repositories
{
    internal class UnitRepository:GenericRepository<Unit>,IUnitRepository
    {
        public UnitRepository(DbContextClass dbContext) : base(dbContext)
        {
            
        }
    }
}
