using Shipping.Entities.Models;
using Shipping.Repositories;
using Shipping.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CustomerService: ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Task<IEnumerable<Customer>> GetAllAsync()
    {
        return _customerRepository.GetAllAsync();
    }

    public Task<Customer> GetByIdAsync(int id)
    {
        return _customerRepository.GetByIdAsync(id);
    }

    public Task AddAsync(Customer customer)
    {
        return _customerRepository.AddAsync(customer);
    }

    public Task UpdateAsync(Customer customer, int id)
    {
        return _customerRepository.UpdateAsync(customer);
    }

    public async Task DeleteAsync(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer != null)
        {
            await _customerRepository.DeleteAsync(customer);
        }
    }

    public Task SaveChangesAsync()
    {
        return _customerRepository.SaveChangesAsync();
    }
}

