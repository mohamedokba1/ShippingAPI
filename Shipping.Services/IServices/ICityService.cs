using Shipping.Services.Dtos;

public interface ICityService
{
    public Task<IEnumerable<CityReadDto>> GetAllAsync();
    public Task<CityReadDto>? GetByIdAsync(int id);
    public Task AddAsync(CityAddDto cityAddDto);
    public Task UpdateAsync(CityUpdateDto cityUpdateDto, int id);
    public Task DeleteAsync(CityDeleteDto cityDeleteDto);
    public Task SaveChangesAsync();
}
