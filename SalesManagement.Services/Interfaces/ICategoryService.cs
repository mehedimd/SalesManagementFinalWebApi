using SalesManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<bool> CreateCategory(Category category);

        Task<IEnumerable<Category>> GetAllCategorys();

        Task<Category> GetCategoryById(int categoryId);

        Task<bool> UpdateCategory(Category category);

        Task<bool> DeleteCategory(int categoryId);
    }
}
