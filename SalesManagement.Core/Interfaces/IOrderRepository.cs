using SalesManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Core.Interfaces
{
    public interface IOrderRepository:IGenericRepository<Order>
    {
        public System.Object GetAllOrderAnonomous();
        public System.Object GetOrderByIdAnonomous(int id);
        public bool UpdateOrderAnnonomous(Order order);
    }
}
