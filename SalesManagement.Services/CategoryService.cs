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
    public class CategoryService:ICategoryService
    {
        public IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateCategory(Category category)
        {
            if (category != null)
            {
                await _unitOfWork.Categories.Add(category);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            if (categoryId > 0)
            {
                var category = await _unitOfWork.Categories.GetById(categoryId);
                if (category != null)
                {
                    _unitOfWork.Categories.Delete(category);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Category>> GetAllCategorys()
        {
            var categoryList = await _unitOfWork.Categories.GetAll();
            return categoryList;
        }

        public async Task<Category> GetCategoryById(int categoryId)
        {
            if (categoryId > 0)
            {
                var category = await _unitOfWork.Categories.GetById(categoryId);
                if (category != null)
                {
                    return category;
                }
            }
            return null;
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            if (category != null)
            {
                var categoryFind = await _unitOfWork.Categories.GetById(category.CategoryId);
                if (categoryFind != null)
                {
                    categoryFind.CategoryName = category.CategoryName;


                    _unitOfWork.Categories.Update(categoryFind);

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
