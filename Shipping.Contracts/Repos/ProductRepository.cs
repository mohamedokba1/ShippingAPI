using Microsoft.EntityFrameworkCore;
using Shipping.Entities;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories.Contracts;

namespace Shipping.Repositories.Repos;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task AddProductAsync(Product product)
    {
        await _context.Set<Product>().AddAsync(product);
        await SaveChangesAsync();
    }

    public async Task DeleteProductAsync(Product product)
    {
        _context.Set<Product>().Remove(product);
        await SaveChangesAsync();
    }

    public  async Task<IEnumerable<Product>> GetAllProductsAsync(Order order)
    {
        return await _context.Set<Product>()
            .Where(product => product.Order == order)
            .ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(long id)
    {
        return await _context.Set<Product>().FindAsync(id);
    }

    public IQueryable<Product> GetProductPaginated()
    {
        return _context.Set<Product>().AsQueryable();

    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
        
    }
    public async Task UpdateProductAsync(long id, Product? product)
    {
        
    }
}
