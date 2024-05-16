using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesManagement.Core.Models;
using SalesManagement.Infrastructure;
using SalesManagement.Services.Interfaces;

namespace SalesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService context)
        {
            this.orderService = context;
        }

        // GET: api/Orders
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        //{
        //    var orders = await orderService.GetAllOrders();
        //  if (orders == null)
        //  {
        //      return NotFound();
        //  }
        //    return Ok(orders);
        //}

        public  System.Object GetOrders()
        {
            var orders =  orderService.GetAllOrderAnonomous();
            if (orders == null)
            {
                return NotFound();
            }
            return orders;
        }
        // GET: api/Orders/5
        [HttpGet("{id}")]
        public System.Object GetOrder(int id)
        {
            var order =  orderService.GetOrderByIdAnonomous(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public System.Object PutOrder( Order order)
        {
            if (order != null)
            {
                var isUpdated =  orderService.UpdateOrderAnnonomous(order);
                if (isUpdated)
                {
                    return Ok("order updated successfully");
                }
            }
            return BadRequest();
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            if (order != null)
            {
                var isCreated = await orderService.CreateOrder(order);
                if (isCreated)
                {
                    return Ok("Successfully Created");
                }
            }
            return BadRequest();
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var isDeleted = await orderService.DeleteOrder(id);

            if (isDeleted)
            {
                return Ok("Order Successfully Deleted");
            }

            return BadRequest();
        }
    }
}
