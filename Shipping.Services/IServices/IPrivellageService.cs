using Shipping.Services.Dtos;

namespace Shipping.Services.IServices;

public interface IPrivellageService
{
    Task<IEnumerable<PrivellageDto>> GetAllAsync();
    Task<PrivellageDto> GetByIdAsync(Guid id);
    Task AddAsync(PrivellageDto privellgeDto);
    Task UpdateAsync(PrivellageDto privellgeDto, Guid id);
    Task DeleteAsync(Guid id);
}
