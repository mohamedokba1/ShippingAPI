using Shipping.Entities.Domain.Models;

namespace Shipping.Repositories;

public interface ICityRepository
{
    Task<IEnumerable<City>> GetAllAsync();
    Task<City?> GetByIdAsync(int id);
    Task<City?> GetByNameAsync(string cityName);
    Task<IEnumerable<City>> GetCitiesByGovernmentNameAsync(string governmentName);
    Task AddAsync(City entity);
    Task UpdateAsync(City entity);
    Task DeleteAsync(City entity);
    Task SaveChangesAsync();
    IQueryable<City> GetCityPaginated();

}
