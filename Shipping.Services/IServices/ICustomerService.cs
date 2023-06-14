using Shipping.Services.Dtos;

public interface ICustomerService
{
    public Task<IEnumerable<CustomerReadDto>> GetAllAsync();
    public Task<CustomerReadDto>? GetByIdAsync(long id);
    public Task AddAsync(CustomerAddDto customerAddDto);
    public Task UpdateAsync(CustomerUpdateDto customerUpdateDto, long id);
    public Task DeleteAsync(long id);
    public Task SaveChangesAsync();
}

