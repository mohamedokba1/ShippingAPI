using Shipping.Services.Dtos;

public interface ICityService
{
    public Task<IEnumerable<CityReadDto>> GetAllAsync();
    public Task<CityReadDto?> GetByIdAsync(int id);
    public Task<CityReadDto?> GetByNameAsync(string cityName);
    public Task<IEnumerable<CityReadDto>> GetCitiesByGovernmentNameAsync(string governmentName);
    public Task AddAsync(CityAddDto cityAddDto);
    public Task UpdateAsync(CityUpdateDto cityUpdateDto, int id);
    public Task DeleteAsync(int id);
    public Task SaveChangesAsync();
    IQueryable<CityReadDto> GetCitiesPaginated();

}
