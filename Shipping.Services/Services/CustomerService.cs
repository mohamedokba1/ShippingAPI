using AutoMapper;
using AutoMapper.QueryableExtensions;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories.Contracts;
using Shipping.Repositories.Repos;
using Shipping.Services.Dtos;

namespace Shipping.Services.Services;
public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerReadDto>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<CustomerReadDto>>(await _customerRepository.GetAllAsync());
    }

    public async Task<CustomerReadDto?> GetByIdAsync(long id)
    {
        return _mapper.Map<CustomerReadDto>(await _customerRepository.GetByIdAsync(id));
    }

    public async Task<int> AddAsync(CustomerAddDto customerAddDto)
    {
        await _customerRepository.AddAsync(_mapper.Map<Customer>(customerAddDto));
        return await _customerRepository.SaveChangesAsync();
    }

    public async Task UpdateAsync(CustomerUpdateDto customerUpdateDto, long id)
    {
        Customer? customer = _mapper.Map<Customer>(await GetByIdAsync(id));
        if (customer != null)
            await _customerRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        Customer? customer = _mapper.Map<Customer>(await GetByIdAsync(id));
        if(customer != null)
        {
            await _customerRepository.DeleteAsync(customer);
            await _customerRepository.SaveChangesAsync();
        }
    }

    public IQueryable<CustomerReadDto> GetCustomersPaginated()
    {
        IQueryable customers = _customerRepository.GetCustomersPaginated();
        return customers.ProjectTo<CustomerReadDto>(_mapper.ConfigurationProvider);
    }
}

