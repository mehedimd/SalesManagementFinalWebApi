using SalesManagement.Core.Interfaces;
using SalesManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Infrastructure.Repositories
{
    internal class ProductRepository: GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContextClass dbContext):base(dbContext)
        {
            
        }
    }
}
