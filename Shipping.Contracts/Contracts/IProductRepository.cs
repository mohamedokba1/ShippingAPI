using Shipping.Entities.Models;

namespace Shipping.Repositories.Contracts;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Product product);
    Task <IEnumerable<Product>> GetAllAsync();
    Task <Product>? GetByIdAsync(int id);
    
    
}
