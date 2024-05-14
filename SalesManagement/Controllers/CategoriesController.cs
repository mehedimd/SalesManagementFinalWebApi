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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService context)
        {
            categoryService = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {

          var allCategory = await categoryService.GetAllCategorys();
          if (allCategory == null)
          {
              return NotFound();
          }
            return Ok(allCategory);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await categoryService.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }
            if(category != null)
            {
                var isCategoryUpdated = await categoryService.UpdateCategory(category);
                if (isCategoryUpdated)
                {
                    return Ok(isCategoryUpdated);
                }
                return BadRequest();
            }
            return BadRequest();
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            if(category != null)
            {
                var isCategoryCreated = await categoryService.CreateCategory(category);
                if (isCategoryCreated)
                {
                    return Ok(isCategoryCreated);
                }               
            }
            return BadRequest();
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var isDeleted = await categoryService.DeleteCategory(id);
            if (isDeleted)
            {
                return Ok(isDeleted);
            }
            return BadRequest();
        }

    }
}
