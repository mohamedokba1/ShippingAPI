using AutoMapper;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories.Contracts;
using Shipping.Services.Dtos;
using Shipping.Services.Dtos.ProductDtos;
using Shipping.Services.IServices;

namespace Shipping.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public Task AddAsync(AddProductDto product)
        {
              Product ProductToAdd=_mapper.Map<Product>(product);
            
              _productRepository.AddAsync(ProductToAdd);
            
              return Task.CompletedTask;
        }

       

        public async Task DeleteAsync(long id)
        {
            var productToDelete = await _productRepository.GetByIdAsync( id);
            if (productToDelete != null)
            {
                await _productRepository.DeleteAsync(productToDelete);
                
            }
        }

        public  async Task<ProductReadDtos>? GetProductByIdAsync(long id)
        {
            
            var productFromDB=await _productRepository.GetByIdAsync(id);
            if(productFromDB != null)
            {
                return _mapper.Map<ProductReadDtos>(productFromDB);
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<ProductReadDtos>> GetProductsAsync()
        {
            var allProduct=await  _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductReadDtos>>(allProduct);
        }

        public  async Task UpdateAsync(long id, ProductUpdateDtos product)
        {
            Product productToUpdate =await  _productRepository.GetByIdAsync(id);
            if (productToUpdate != null)
            {
                

                productToUpdate.ProductName = product.ProductName;
                productToUpdate.Price = product.Price;
                productToUpdate.Weight = product.Weight;
               
                
            }

            
             
        }

    }
}
