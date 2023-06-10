using Shipping.Services.Dtos;

public interface ICustomerService
{
    public Task<IEnumerable<CustomerReadDto>> GetAllAsync();
    public Task<CustomerReadDto>? GetByIdAsync(Guid id);
    public Task AddAsync(CustomerAddDto customerAddDto);
    public Task UpdateAsync(CustomerUpdateDto customerUpdateDto, Guid id);
    public Task DeleteAsync(Guid id);
    public Task SaveChangesAsync();
}

