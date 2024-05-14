using SalesManagement.Core.Interfaces;
using SalesManagement.Core.Models;
using SalesManagement.Services.Interfaces;

namespace SalesManagement.Services
{
    public class ProductService: IProductService
    {
        public IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateProduct(Product product)
        {
            if (product != null)
            {
                await _unitOfWork.Products.Add(product);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            if (productId > 0)
            {
                var product = await _unitOfWork.Products.GetById(productId);
                if (product != null)
                {
                    _unitOfWork.Products.Delete(product);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var product = await _unitOfWork.Products.GetAll();
            return product;
        }

        public async Task<Product> GetProductById(int productId)
        {
            if (productId > 0)
            {
                var product = await _unitOfWork.Products.GetById(productId);
                if (product != null)
                {
                    return product;
                }
            }
            return null;
        }

        public async Task<bool> UpdateProduct(Product newProduct)
        {
            if (newProduct != null)
            {
                var product = await _unitOfWork.Products.GetById(newProduct.ProductId);
                if (product != null)
                {
                    product.ProductName = newProduct.ProductName;
                    product.ProductDescription = newProduct.ProductDescription;
                    product.Price = newProduct.Price;

                    _unitOfWork.Products.Update(product);

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
