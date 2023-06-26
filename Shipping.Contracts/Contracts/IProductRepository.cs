using Shipping.Entities.Domain.Models;

namespace Shipping.Repositories.Contracts;

public interface IProductRepository
{
    Task AddProductAsync(Product product);
    Task UpdateProductAsync(long id, Product? product);
    Task DeleteProductAsync(Product product);
    Task <IEnumerable<Product>> GetAllProductsAsync(Order order);
    Task <Product?> GetByIdAsync(long id);
    Task SaveChangesAsync();
    IQueryable<Product> GetProductPaginated();

}
