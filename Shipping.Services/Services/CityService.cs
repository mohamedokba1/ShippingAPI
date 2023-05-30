using Shipping.Entities.Models;
using Shipping.Repositories;
using Shipping.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

    public Task AddAsync(City city)
    {
        return _cityRepository.AddAsync(city);
    }

    public Task UpdateAsync(City city, int id)
    {
        return _cityRepository.UpdateAsync(city);
    }

    public async Task DeleteAsync(int id)
    {
        var city = await _cityRepository.GetByIdAsync(id);
        if (city != null)
        {
            await _cityRepository.DeleteAsync(city);
        }
    }

    public Task SaveChangesAsync()
    {
        return _cityRepository.SaveChangesAsync();
    }
}

