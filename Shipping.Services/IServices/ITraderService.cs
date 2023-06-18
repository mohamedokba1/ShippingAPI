using Shipping.Services.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.IServices;

public interface ITraderService
{
    Task<IEnumerable<TraderResponseDto>?> GetAllTradersAsync();
<<<<<<< HEAD
    Task<TraderResponseDto> GetTraderByIdAsync(string id);
    Task<long> GetTraderIdByEmail(string email);
    Task<TraderResponseDto?> AddTraderAsync(TraderAddDto traderAddDto);
    Task<bool> UpdateTraderAsync(string trader_id, TraderUpdateDto traderUpdateDto);
    Task<bool> DeleteTraderAsync(string trader_id);
=======
>>>>>>> 172b95938d700ce48f2dea7829dfb423d4db440b
    Task<TraderResponseDto> GetTraderByIdAsync(long id);
    Task<long> GetTraderIdByEmailAsync(string trdaerEmail);
    Task<List<ValidationResult>?> AddUserAndTrader(TraderAddDto traderAddDto);
    Task<List<ValidationResult>?> UpdateTraderAsync(long trader_id, TraderUpdateDto traderUpdateDto);
    Task<bool> DeleteTraderAsync(long trader_id);
    IQueryable<TraderResponseDto> GetTradersPaginated();
    Task<IEnumerable<TraderResponseDto>> GetFilteredTradersAsync(string searchString);
}
