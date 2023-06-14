using Microsoft.AspNetCore.Http;
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
            if (customer == null)
            {
                return BadRequest("Customer is Null.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _customerService.AddAsync(customer);

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerId }, customer);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCustomer(long id, CustomerUpdateDto customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest("Customer is Null.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ExistingCustomer = await _customerService.GetByIdAsync(id);
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
            {
                return NotFound();
            }
            await _customerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
