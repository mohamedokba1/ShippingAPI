using Shipping.Entities.Domain.Models;

namespace Shipping.Repositories.Contracts;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task UpdateAsync(long id, Product? product);
    Task DeleteAsync(Product product);
    Task <IEnumerable<Product>> GetAllAsync();
    Task <Product>? GetByIdAsync(long id);
    Task saveChanges();
    
}
