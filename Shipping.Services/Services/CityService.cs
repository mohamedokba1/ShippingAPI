using Shipping.Entities.Models;
using Shipping.Services.IServices;
using Shipping.Services.Validations;
using Shipping.Repositories;

namespace Shipping.Services.Services;
public class CityService:ICityService
{
    private readonly ICityRepository _cityRepository;

    public CityService(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }
    public Task<IEnumerable<City>> GetAllAsync()
    {
        return _cityRepository.GetAllAsync();
    }
    public Task<City> GetByIdAsync(int id)
    {
        return _cityRepository.GetByIdAsync(id);
    }
    public async Task AddAsync(City city)
    {
        if(city != null)
        {
            ValidateModel.ModelValidation(city);
            await _cityRepository.AddAsync(city);
            await _cityRepository.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(City city, int id)
    {
        if (city != null)
        {
            ValidateModel.ModelValidation(city);
            await _cityRepository.UpdateAsync(city);
            await _cityRepository.SaveChangesAsync();
        }
    }
    public async Task DeleteAsync(int id)
    {
        var city = await _cityRepository.GetByIdAsync(id);
        if (city != null)
        {
            ValidateModel.ModelValidation(city);
            await _cityRepository.DeleteAsync(city);
            await _cityRepository.SaveChangesAsync();
        }
    }
    public async Task SaveChangesAsync()
    {
        await _cityRepository.SaveChangesAsync();
    }
}

