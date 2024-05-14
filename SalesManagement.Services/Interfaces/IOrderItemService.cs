using SalesManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Services.Interfaces
{
    public interface IOrderItemService
    {
        Task<bool> CreateOrderItem(OrderItems orderItems); 
        Task<OrderItems> GetOrderItemsById(int orderItemsid);
        Task<IEnumerable<OrderItems>> GetAllOrderItems();
        Task<bool> UpdateOrderItems(OrderItems orderItems);
        Task<bool> DeleteOrderItem(int orderItemsid);
    }
}
