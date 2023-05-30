using Shipping.Entities.Models;
using Shipping.Services.Validations;
using Shipping.Repositories.Contracts;



public class CustomerService: ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _customerRepository.GetAllAsync();
    }

    public async Task<Customer>? GetByIdAsync(Guid id)
    {
        return await _customerRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(Customer customer)
    {
        if (customer != null)
        {
            ValidateModel.ModelValidation(customer);
            await _customerRepository.AddAsync(customer); ;
            await _customerRepository.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(Customer customer, Guid id)
    {
        if (customer != null)
        {
            ValidateModel.ModelValidation(customer);
            await _customerRepository.UpdateAsync(customer);
            await _customerRepository.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer != null)
        {
            ValidateModel.ModelValidation(customer);
            await _customerRepository.DeleteAsync(customer);
            await _customerRepository.SaveChangesAsync();
        }
    }

    public async Task SaveChangesAsync()
    {
        await _customerRepository.SaveChangesAsync();
    }

}

