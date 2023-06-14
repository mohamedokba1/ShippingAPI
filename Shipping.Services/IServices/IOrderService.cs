using Shipping.Services.Dtos;

namespace Shipping.Services.IServices
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderReadDto>> GetAllAsync();
<<<<<<< HEAD
        Task<OrderResponseDto> GetByIdAsync(Guid id);
=======
        Task<OrderReadDto> GetByIdAsync(long id);
>>>>>>> fd8e4736c771af946ab51aa18e7080e323d17591
        Task AddAsync(OrderAddDto orderDto);
        Task UpdateAsync(OrderUpdateDto orderUpdateDto, long id);
        Task DeleteAsync(long id);
    }
}
