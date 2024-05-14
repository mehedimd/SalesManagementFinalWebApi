using SalesManagement.Core.Interfaces;
using SalesManagement.Core.Models;
using SalesManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Services
{
    public class OrderItemsService : IOrderItemService
    {
        public IUnitOfWork _unitOfWork;
        public OrderItemsService(IUnitOfWork context)
        {
            _unitOfWork = context;
        }



        public async Task<bool> CreateOrderItem(OrderItems orderItems)
        {
            if (orderItems != null)
            {
                await _unitOfWork.OrderItems.Add(orderItems);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }



        public async Task<bool> DeleteOrderItem(int orderItemsid)
        {
            if (orderItemsid > 0)
            {
                var orderItem = await _unitOfWork.OrderItems.GetById(orderItemsid);
                if (orderItem != null)
                {
                    _unitOfWork.OrderItems.Delete(orderItem);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<OrderItems>> GetAllOrderItems()
        {
            var orderItemList = await _unitOfWork.OrderItems.GetAll();
            return orderItemList;
        }

        
        public async Task<OrderItems> GetOrderItemsById(int orderItemsid)
        {
            if(orderItemsid > 0)
            {
                var orderItem = await _unitOfWork.OrderItems.GetById(orderItemsid);
                if(orderItem != null)
                {
                    return orderItem;
                }
                
            }
            return null;
        }

        public async Task<bool> UpdateOrderItems(OrderItems orderItems)
        {
            if (orderItems != null)
            {
                var orderItemsFind = await _unitOfWork.OrderItems.GetById(orderItems.Id);
                if (orderItemsFind != null)
                {
                    orderItemsFind.Quantity=orderItems.Quantity;
                    orderItemsFind.ProductId = orderItems.ProductId;
                    orderItemsFind.OrderId = orderItems.OrderId;
                    _unitOfWork.OrderItems.Update(orderItemsFind);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

    }
}
