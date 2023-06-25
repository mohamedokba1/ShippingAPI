using Shipping.Entities.Domain.Models;
using Shipping.Services.Dtos;

namespace Shipping.Services.IServices;

public interface IProductService
{
    public Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync(Order order);
    public  Task<ProductResponseDto?> GetProductByIdAsync(long id);
    public Task AddProductAsync(ProductAddDto product);
    public Task UpdateProductAsync(long id, ProductUpdateDto product);
    public Task DeleteProductAsync(long id);
    IQueryable<ProductResponseDto> GetProductsPaginated();

}
