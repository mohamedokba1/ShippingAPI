using Microsoft.EntityFrameworkCore;
using Shipping.Entities;
using Shipping.Entities.Models;
using Shipping.Repositories;


public class CityRepository : ICityRepository
{
    private readonly ApplicationDbContext _context;
    public CityRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<City>> GetAllAsync()
    {
        return await _context.Set<City>().ToListAsync();
    }

    public async Task<City> GetByIdAsync(int id)
    {
        return await _context.Set<City>().FindAsync(id);
    }

    public async Task AddAsync(City entity)
    {
        await _context.Set<City>().AddAsync(entity);
    }

    public async Task UpdateAsync(City entity)
    {
        _context.Set<City>().Update(entity);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(City entity)
    {
        _context.Set<City>().Remove(entity);
        await Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public IEnumerable<City> GetAll()
    {
        throw new NotImplementedException();
    }
}
