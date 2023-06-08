using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories;
using Shipping.Services.Dtos;
using Shipping.Services.Validations;


namespace Shipping.Services.Services;
public class CityService: ICityService
{
    private readonly ICityRepository _cityRepository;

    public CityService(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }
    public async Task<IEnumerable<CityReadDto>> GetAllAsync()
    {
        var cities = await _cityRepository.GetAllAsync();
        return cities.Select(city => new CityReadDto
        {
            CityId = city.City_Id,
            CityName = city.CityName,
            NormalShippingCost = city.NormalShippingCost
        });
    }
    public async Task<CityReadDto> GetByIdAsync(int id)
    {
        var city = await _cityRepository.GetByIdAsync(id);
        if (city != null)
        {
            return new CityReadDto
            {
                CityId = city.City_Id,
                CityName = city.CityName,
                NormalShippingCost = city.NormalShippingCost
            };
        }
        return null!;
    }
    public async Task AddAsync(CityAddDto cityAddDto)
    {
        if (cityAddDto != null)
        {
            var city = new City
            {
                CityName = cityAddDto.CityName,
                NormalShippingCost = cityAddDto.NormalShippingCost,
                GovermentId = cityAddDto.GovernmentId
            };
            ValidateModel.ModelValidation(city);

            await _cityRepository.AddAsync(city);
            await _cityRepository.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(CityUpdateDto cityUpdateDto, int id)
    {

        if (cityUpdateDto != null)
        {
            var city = await _cityRepository.GetByIdAsync(id);
            if (city != null)
            {
                city.CityName = cityUpdateDto.CityName;
                city.NormalShippingCost = cityUpdateDto.NormalShippingCost;
                ValidateModel.ModelValidation(city);

                await _cityRepository.UpdateAsync(city);
                await _cityRepository.SaveChangesAsync();
            }
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

