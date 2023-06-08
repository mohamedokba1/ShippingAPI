using Shipping.Entities.Domain.Models;
using Shipping.Services.Dtos;
using Shipping.Services.Dtos.ProductDtos;

namespace Shipping.Services.IServices;

public interface IProductService
{
    public Task<IEnumerable<ProductReadDtos>> GetProductsAsync();
    
    public Task<ProductReadDtos> GetProductByIdAsync(Guid id);
    public Task AddAsync(AddProductDto product);
    public Task UpdateAsync(Guid id,ProductUpdateDtos product);
    public Task DeleteAsync(Guid id);
    

}
