using AutoMapper;
using AutoMapper.QueryableExtensions;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories;
using Shipping.Repositories.Contracts;
using Shipping.Services.Dtos;
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
        public async Task AddProductAsync(ProductAddDto productAddDto)
        {
              Product ProductToAdd = _mapper.Map<Product>(productAddDto);
              await _productRepository.AddProductAsync(ProductToAdd);
        }

        public async Task DeleteProductAsync(long productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product != null)
                await _productRepository.DeleteProductAsync(product);
        }

        public  async Task<ProductResponseDto?> GetProductByIdAsync(long id)
        {
            var productFromDB=await _productRepository.GetByIdAsync(id);
            if(productFromDB != null)
                return _mapper.Map<ProductResponseDto>(productFromDB);

            return null;
        }

        public async Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync(Order order)
        {
            var allProduct = await  _productRepository.GetAllProductsAsync(order);
            return _mapper.Map<IEnumerable<ProductResponseDto>>(allProduct);
        }

        public  async Task UpdateProductAsync(long id, ProductUpdateDto productUpdateDto)
        {
            Product? product = await _productRepository.GetByIdAsync(id);
            if(product != null) 
            {
                _mapper.Map<ProductUpdateDto, Product>(productUpdateDto, product);
                await _productRepository.SaveChangesAsync();
            }
        }

        public IQueryable<ProductResponseDto> GetProductsPaginated()
        {
            IQueryable products = _productRepository.GetProductPaginated();
            return products.ProjectTo<ProductResponseDto>(_mapper.ConfigurationProvider);
        }
    }
}
