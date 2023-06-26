using AutoMapper;
using AutoMapper.QueryableExtensions;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories;
using Shipping.Services.Dtos;
using Shipping.Services.Validations;

namespace Shipping.Services.Services;
public class CityService: ICityService
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public CityService(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<CityReadDto>> GetAllAsync()
    {
        var cities = await _cityRepository.GetAllAsync();
        return cities.Select(city => new CityReadDto
        {
            City_Id = city.City_Id,
            CityName = city.CityName,
            NormalShippingCost = city.NormalShippingCost,
            PickupShippingCost= city.PickupShippingCost,
            govermentName= city.goverment.GovermentName
        });
    }
    public async Task<CityReadDto> GetByIdAsync(int id)
    {
        var city = await _cityRepository.GetByIdAsync(id);
        if (city != null)
        {
            return new CityReadDto
            {
                City_Id = city.City_Id,
                CityName = city.CityName,
                NormalShippingCost = city.NormalShippingCost,
                PickupShippingCost=city.PickupShippingCost,
                govermentName = city.goverment!.GovermentName,
            };
        }
        return null!;
    }
    public async Task<IEnumerable<CityReadDto>> GetCitiesByGovernmentNameAsync(string governmentName)
    {
        var cities = await _cityRepository.GetCitiesByGovernmentNameAsync(governmentName);
        return cities.Select(city => new CityReadDto
        {
            City_Id = city.City_Id,
            CityName = city.CityName,
            NormalShippingCost = city.NormalShippingCost,
            PickupShippingCost = city.PickupShippingCost,
            govermentName = city.goverment.GovermentName
        });
    }
    public async Task AddAsync(CityAddDto cityAddDto)
    {
        if (cityAddDto != null)
        {
            var city = new City
            {
                CityName = cityAddDto.CityName,
                NormalShippingCost = cityAddDto.NormalShippingCost,
                PickupShippingCost = cityAddDto.PickupShippingCost,
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
                city.PickupShippingCost = cityUpdateDto.PickupShippingCost;
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

    public async Task<CityReadDto?> GetByNameAsync(string cityName)
    {
        return _mapper.Map<CityReadDto>(await _cityRepository.GetByNameAsync(cityName));
    }

    public IQueryable<CityReadDto> GetCitiesPaginated()
    {
        IQueryable cities = _cityRepository.GetCityPaginated();
        return cities.ProjectTo<CityReadDto>(_mapper.ConfigurationProvider);
    }
}

