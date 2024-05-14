using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesManagement.Core.Models;
using SalesManagement.Infrastructure;
using SalesManagement.Services;
using SalesManagement.Services.Interfaces;

namespace SalesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemService service;

        public OrderItemsController(IOrderItemService context)
        {
            service = context;
        }

        // GET: api/OrderItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetOrderItems()
        {
            var allOrderItems = await service.GetAllOrderItems();
            if (allOrderItems == null)
            {
                return NotFound();
            }
            return Ok(allOrderItems);
        }

        // GET: api/OrderItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItems>> GetOrderItemsById(int id)
        {
            var orderItem = await service.GetOrderItemsById(id);
          if (orderItem == null)
          {
              return NotFound("OrderItem is not available");
          }
            return Ok(orderItem);
        }

        // PUT: api/OrderItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderItems(OrderItems orderItems)
        {
            if (orderItems != null)
            {
                var isUpdated = await service.UpdateOrderItems(orderItems);
                if (isUpdated)
                {
                    return Ok("Successfully Updated");
                }
                return BadRequest("Update Failled");
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/OrderItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderItems>> PostOrderItem(OrderItems orderItems)
        {
            var isCreated = await service.CreateOrderItem(orderItems);
            if (isCreated)
            {
                return Ok("Created Successfully");
            }
            else
            {
                return BadRequest("cration Failled");
            }
        }

        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            var isDeleted = await service.DeleteOrderItem(id);
            if (isDeleted)
            {
                return Ok("Deleted Successfully");
            }
            else
            {
                return BadRequest("Failled to delete.");
            }

        }

       
    }
}
