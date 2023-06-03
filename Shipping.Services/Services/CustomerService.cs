using Shipping.Entities.Models;
using Shipping.Services.Validations;
using Shipping.Repositories.Contracts;
using Shipping.Services.Dtos;

namespace Shipping.Services.Services;
public class CustomerService: ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<IEnumerable<CustomerReadDto>> GetAllAsync()
    {
        var customers = await _customerRepository.GetAllAsync();
        return customers.Select(customer => new CustomerReadDto
        {
            CustomerId = customer.Customer_Id,
            Email = customer.Email,
            Name = customer.Name,
            Goverment = customer.Goverment,
            City = customer.City,
            Village = customer.Village,
            Phone1 = customer.Phone1,
            Phone2 = customer.Phone2
        });
    }

    public async Task<CustomerReadDto> GetByIdAsync(Guid id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer != null)
        {
            return new CustomerReadDto
            {
                CustomerId = customer.Customer_Id,
                Email = customer.Email,
                Name = customer.Name,
                Goverment = customer.Goverment,
                City = customer.City,
                Village = customer.Village,
                Phone1 = customer.Phone1,
                Phone2 = customer.Phone2
            };
        }
        return null;
    }

    public async Task AddAsync(CustomerAddDto customerAddDto)
    {
        if (customerAddDto != null)
        {
            var customer = new Customer
            {
                Email = customerAddDto.Email,
                Name = customerAddDto.Name,
                Goverment = customerAddDto.Goverment,
                City = customerAddDto.City,
                Village = customerAddDto.Village,
                Phone1 = customerAddDto.Phone1,
                Phone2 = customerAddDto.Phone2
            };
            ValidateModel.ModelValidation(customer);

            await _customerRepository.AddAsync(customer);
            await _customerRepository.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(CustomerUpdateDto customerUpdateDto, Guid id)
    {
        if (customerUpdateDto != null)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer != null)
            {
                customer.Email = customerUpdateDto.Email;
                customer.Name = customerUpdateDto.Name;
                customer.Goverment = customerUpdateDto.Goverment;
                customer.City = customerUpdateDto.City;
                customer.Village = customerUpdateDto.Village;
                customer.Phone1 = customerUpdateDto.Phone1;
                customer.Phone2 = customerUpdateDto.Phone2;
                ValidateModel.ModelValidation(customer);

                await _customerRepository.UpdateAsync(customer);
                await _customerRepository.SaveChangesAsync();
            }
        }
    }

    public async Task DeleteAsync(CustomerDeleteDto customerDeleteDto)
    {
        if (customerDeleteDto != null)
        {
            var customer = await _customerRepository.GetByIdAsync(customerDeleteDto.CustomerId);
            if (customer != null)
            {
                ValidateModel.ModelValidation(customer);

                await _customerRepository.DeleteAsync(customer);
                await _customerRepository.SaveChangesAsync();
            }
        }
    }

    public async Task SaveChangesAsync()
    {
        await _customerRepository.SaveChangesAsync();
    }

}

