using Shipping.Services.Dtos;

namespace Shipping.Services.IServices
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderReadDto>> GetAllAsync();
        Task<OrderReadDto> GetByIdAsync(long id);
        Task AddAsync(OrderAddDto orderDto);
        Task UpdateAsync(OrderUpdateDto orderUpdateDto, long id);
        Task DeleteAsync(long id);
    }
}
