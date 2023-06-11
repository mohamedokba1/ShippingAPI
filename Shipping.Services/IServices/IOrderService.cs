using Shipping.Services.Dtos;

namespace Shipping.Services.IServices
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderReadDto>> GetAllAsync();
        Task<OrderReadDto> GetByIdAsync(Guid id);
        Task AddAsync(OrderAddDto orderDto);
        Task UpdateAsync(OrderUpdateDto orderUpdateDto, Guid id);
        Task DeleteAsync(Guid id);
    }
}
