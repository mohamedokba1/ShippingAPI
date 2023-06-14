using Shipping.Services.Dtos;

namespace Shipping.Services.IServices;

public interface IPrivellageService
{
    Task<IEnumerable<PrivellageDto>> GetAllAsync();
    Task<PrivellageDto> GetByIdAsync(long id);
    Task AddAsync(PrivellageDto privellgeDto);
    Task UpdateAsync(PrivellageDto privellgeDto, long id);
    Task DeleteAsync(long id);
}
