using SalesManagement.Core.Interfaces;
using SalesManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Infrastructure.Repositories
{
    public class OrderItemRepository: GenericRepository<OrderItems>,IOrderItemsRepository
    {
        public OrderItemRepository(DbContextClass context) : base(context)
        {
            
        }
    }
}
