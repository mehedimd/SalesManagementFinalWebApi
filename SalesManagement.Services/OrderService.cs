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
    public class OrderService: IOrderService
    {
        public IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateOrder(Order order)
        {
            if (order != null)
            {
                await _unitOfWork.Orders.Add(order);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteOrder(int orderId)
        {
            if (orderId > 0)
            {
                var order = await _unitOfWork.Orders.GetById(orderId);
                if (order != null)
                {
                    _unitOfWork.Orders.Delete(order);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            var orderList = await _unitOfWork.Orders.GetAll();
            return orderList;
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            if (orderId > 0)
            {
                var order = await _unitOfWork.Orders.GetById(orderId);
                if (order != null)
                {
                    return order;
                }
            }
            return null;
        }
        public async Task<bool> UpdateOrder(Order order)
        {
            if (order != null)
            {
                var orderFind = await _unitOfWork.Orders.GetById(order.OrderId);
                if (orderFind != null)
                {
                    orderFind.OrderDate = order.OrderDate;
                    orderFind.GrandTotal = order.GrandTotal;
                    orderFind.PaymentTotal = order.PaymentTotal;
                    orderFind.TotalDue = order.TotalDue;
                    orderFind.PharmacyId = order.PharmacyId;
                    orderFind.OrderNo = order.OrderNo;

                    _unitOfWork.Orders.Update(orderFind);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
        // extra service
        public  System.Object GetAllOrderAnonomous()
        {
            var orderList =  _unitOfWork.Orders.GetAllOrderAnonomous();
            return orderList;
        }
        // getById
        public System.Object GetOrderByIdAnonomous(int orderId)
        {
            var order = _unitOfWork.Orders.GetOrderByIdAnonomous(orderId);
            return order;
        }
        // update order
        public bool UpdateOrderAnnonomous (Order order)
        {
            var isUpdated = _unitOfWork.Orders.UpdateOrderAnnonomous( order);
            return isUpdated;
        }

    }
}
