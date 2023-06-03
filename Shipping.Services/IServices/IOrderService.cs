using Shipping.Services.Dtos;

namespace Shipping.Services.IServices
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderReadDto>> GetAllAsync();
        Task<OrderReadDto> GetByIdAsync(Guid id);
        Task AddAsync(OrderAddDto orderDto);
        Task UpdateAsync(OrderAddDto orderDto, Guid id);
        Task DeleteAsync(Guid id);
    }
}
