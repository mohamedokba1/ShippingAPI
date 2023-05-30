using Shipping.Entities.Models;
using Shipping.Entities;
using Shipping.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Shipping.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;
    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.Set<Customer>().ToListAsync();
    }

    public async Task<Customer>? GetByIdAsync(Guid id)
    {
         return await _context.Set<Customer>().FindAsync(id);
    }
    public async Task AddAsync(Customer entity)
    {
        await _context.AddAsync(entity);
    }
    public async Task UpdateAsync(Customer entity)
    {
        _context.Update(entity);
        await Task.CompletedTask;
    }
    public async Task DeleteAsync(Customer entity)
    {
        _context.Set<Customer>().Remove(entity);
        await Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public Task<Customer>? GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
