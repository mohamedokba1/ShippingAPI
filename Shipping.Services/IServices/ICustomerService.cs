using Shipping.Entities.Domain.Models;
using Shipping.Services.Dtos;

public interface ICustomerService
{
    Task<IEnumerable<CustomerReadDto>> GetAllAsync();
    Task<CustomerReadDto?> GetByIdAsync(long id);
    Task<int> AddAsync(CustomerAddDto customerAddDto);
    Task UpdateAsync(CustomerUpdateDto customerUpdateDto, long id);
    Task DeleteAsync(long id);
    IQueryable<CustomerReadDto> GetCustomersPaginated();

}