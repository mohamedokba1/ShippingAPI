using Shipping.Entities.Models;
using Shipping.Services.Dtos.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.IServices
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderReadDto>> GetAllAsync();
        Task<OrderReadDto> GetByIdAsync(Guid id);
        Task AddAsync(OrderDto orderDto);
        Task UpdateAsync(OrderDto orderDto, Guid id);
        Task DeleteAsync(Guid id);
    }
}
