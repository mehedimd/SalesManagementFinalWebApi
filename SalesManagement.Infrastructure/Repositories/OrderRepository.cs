using SalesManagement.Core.Models;
using SalesManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Infrastructure.Repositories
{
    internal class OrderRepository:GenericRepository<Order>,IOrderRepository
    {
        private readonly DbContextClass db;
        public OrderRepository(DbContextClass dbContext) : base(dbContext)
        {
            this.db = dbContext;
        }
        // get All
        public  System.Object GetAllOrderAnonomous()
        {
            var orderList = from o in db.Orders
                            join pharmacy in db.Pharmacies
                            on o.PharmacyId equals pharmacy.PharmacyId
                            select new
                            {
                                o.OrderId,
                                o.OrderNo,
                                o.OrderDate,
                                o.GrandTotal,
                                o.IsApproved,
                                o.IsDelivered,
                                pharmacy.PharmacyName
                            };
            return orderList;
        }
        // get By Id
        public System.Object GetOrderByIdAnonomous(int id)
        {
            var order = (from o in db.Orders
                        where o.OrderId == id
                        select new
                        {
                            o.OrderId,
                            o.OrderNo,
                            o.OrderDate,
                            o.GrandTotal,
                            o.IsApproved,
                            o.IsDelivered,
                            o.PharmacyId
                        }).FirstOrDefault();
            var orderItems = (from o in db.OrderItems
                             join p in db.Products
                             on o.ProductId equals p.ProductId
                             join u in db.Units
                             on o.UnitId equals u.UnitId
                             where o.OrderId == id
                             select new
                             {
                                 o.Id,
                                 o.OrderId,
                                 o.ProductId,
                                 p.ProductName,
                                 o.UnitId,
                                 u.UnitName,
                                 p.Price,
                                 o.Quantity,
                                 Total = p.Price * o.Quantity

                             }).ToList();
            return new { order,orderItems};
        }
        // update order
        public bool UpdateOrderAnnonomous(Order order)
        {
            db.OrderItems.RemoveRange(db.OrderItems.Where(d => d.OrderId == order.OrderId).ToList());
            db.SaveChanges();
            foreach (var item in order.OrderItems)
            {
                if(item.Id > 0)
                {
                    item.Id = 0;
                }

            }

            db.Attach(order);
            db.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            
            return false;
        }
    }
}
