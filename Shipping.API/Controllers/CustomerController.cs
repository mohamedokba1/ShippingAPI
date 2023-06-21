using Microsoft.AspNetCore.Mvc;
using Shipping.Services.Dtos;

namespace Shipping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerReadDto>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllAsync();
            return Ok(customers);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CustomerReadDto>> GetCustomer(long id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> AddCustomer(CustomerAddDto customer)
        {
            int result = await _customerService.AddAsync(customer);
            if(result > 0)
                return Created("Customer created successfully", customer);
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCustomer(long id, CustomerUpdateDto customer)
        {
            CustomerReadDto? ExistingCustomer = await _customerService.GetByIdAsync(id);
            if (ExistingCustomer == null)
            {
                return NotFound();
            }
            await _customerService.UpdateAsync(customer, id);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCustomer(long id)
        {
            var ExistingCustomer = await _customerService.GetByIdAsync(id);
            if (ExistingCustomer == null)
                return NotFound();
            await _customerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
