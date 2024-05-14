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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService context)
        {
            productService = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var allProducts = await productService.GetAllProducts();
            if (allProducts == null)
            {
                return NotFound();
            }
            return Ok(allProducts);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await productService.GetProductById(id);
            if (product == null)
            {
                return NotFound("Product is not available");
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(Product product)
        {
            if (product != null)
            {
                var isUpdated = await productService.UpdateProduct(product);
                if (isUpdated)
                {
                    return Ok(isUpdated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }  
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {

            var isCreated = await productService.CreateProduct(product);
            if (isCreated)
            {
                return Ok(isCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var isDeleted = await productService.DeleteProduct(id);
            if (isDeleted)
            {
                return Ok(isDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
