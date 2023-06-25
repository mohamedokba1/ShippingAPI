using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shipping.Services.Dtos;

namespace Shipping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerReadDto>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllAsync();
            return Ok(customers);
        }
        //pagination

        [HttpGet("paginated")]
        public async Task<ActionResult<PaginationResponse<CustomerReadDto>>> GetCustomers([FromQuery] PaginationParameters paginationParameters)
        {
            var customers = _customerService.GetCustomersPaginated();
            //_logger.LogError("customers", customers);
            int totalRecords = await customers.CountAsync();

            List<CustomerReadDto>? listOfCustomers = await customers
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .ToListAsync();
            PaginationResponse<CustomerReadDto> result =
                new PaginationResponse<CustomerReadDto>()
                {
                    Data = listOfCustomers,
                    PageNo = paginationParameters.PageNumber,
                    PageSize = paginationParameters.PageSize,
                    TotalRecords = totalRecords
                };
            return Ok(result);
        }



        //

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
