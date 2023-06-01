using Shipping.Entities.Models;
using Shipping.Repositories.Contracts;
using Shipping.Services.IServices;

namespace Shipping.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task AddAsync(Product product)
        {
            return _productRepository.AddAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            var pro = await _productRepository.GetByIdAsync( id);
            if (pro != null)
            {
                await _productRepository.DeleteAsync(pro);
            }
        }

        public  Task<Product> GetProductByIdAsync(int id)
        {
            return  _productRepository.GetByIdAsync(id);
        }

        public  Task<IEnumerable<Product>> GetProductsAsync()
        {
            return  _productRepository.GetAllAsync();
        }

        public  Task UpdateAsync(Product product)
        {
             return _productRepository.UpdateAsync(product);
        }
    }
}
