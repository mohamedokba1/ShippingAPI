using Microsoft.EntityFrameworkCore;
using Shipping.Entities;
using Shipping.Entities.Domain.Models;
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
        return await _context.Set<City>().Include(c=>c.goverment).ToListAsync();
    }

    public async Task<City?> GetByIdAsync(int id)
    {
        return await _context.Set<City>().Include(c => c.goverment).FirstOrDefaultAsync(c=>c.City_Id==id);
    }
    public async Task<IEnumerable<City>> GetCitiesByGovernmentNameAsync(string governmentName)
    {
        return await _context.Cities.Include(c => c.goverment)
            .Where(c => c.goverment.GovermentName == governmentName)
            .ToListAsync();
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

    public async Task<City?> GetByNameAsync(string cityName)
    {
        return await _context.Set<City>().FirstOrDefaultAsync(city => city.CityName == cityName);
    }

    public IQueryable<City> GetCityPaginated()
    {
        return _context.Set<City>().AsQueryable();

    }
}
