using SalesManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Services.Interfaces
{
    public interface IOrderService
    {
        Task<bool> CreateOrder(Order order);

        Task<IEnumerable<Order>> GetAllOrders();

        Task<Order> GetOrderById(int orderId);

        Task<bool> UpdateOrder(Order order);

        Task<bool> DeleteOrder(int orderId);
        System.Object GetAllOrderAnonomous();
        System.Object GetOrderByIdAnonomous(int orderId);
        bool UpdateOrderAnnonomous(Order order);
    }
}
