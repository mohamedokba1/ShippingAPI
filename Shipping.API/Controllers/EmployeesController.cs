using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Shipping.Services.Dtos;
using Shipping.Services.IServices;

namespace Shipping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        private readonly ISalesService _salesService;
        private readonly IOrderService _orderService;

        public EmployeesController(IEmployeeService employeeService,
            ISalesService salesService,
            IOrderService orderService)
        {
            this.employeeService = employeeService;
            _orderService = orderService;
            _salesService = salesService;
        }

        [HttpGet]
        public  async Task<ActionResult<IEnumerable<EmployeeReadDto>>> Getall()
        {
            return Ok(await employeeService.Getall());
        }

        [HttpGet("paginated")]
        public async Task<ActionResult<PaginationResponse<EmployeeReadDto>>> GetEmployee([FromQuery] PaginationParameters paginationParameters)
        {
            var employees = employeeService.GetEmployeesPaginated();

            int totalRecords = await employees.CountAsync();

            List<EmployeeReadDto>? listOfEmployees = await employees
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .ToListAsync();
            PaginationResponse<EmployeeReadDto> result =
                new PaginationResponse<EmployeeReadDto>()
                {
                    Data = listOfEmployees,
                    PageNo = paginationParameters.PageNumber,
                    PageSize = paginationParameters.PageSize,
                    TotalRecords = totalRecords
                };
            return Ok(result);
        }

        [HttpPost]
        [Route("assign")]
        public async Task<ActionResult<EmployeeReadDto>> AssignOrderToSales(long salesId, long orderId)
        {
            var sales  = await _salesService.GetSaleByIdAsync(salesId);
            if(sales != null)
            {
                var order = await _orderService.GetOrderByIdAsync(orderId);
                if (order != null)
                {
                    await employeeService.AssignOrderToSales(sales.SalesRepresentativeId, order.OrderId);
                    return NoContent();
                }
                else { return BadRequest("Order not found"); }
            }
            else
            {
                return BadRequest("Sales representative not found");
            }
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<EmployeeReadDto>> GetById(long id) 
        { 
            EmployeeReadDto? employeeReadDto= await employeeService.GetByid(id);   
            if (employeeReadDto == null)
            {
                return NotFound();
            }
            return Ok(employeeReadDto);
        }


        [HttpPost]
        public async Task<ActionResult> Add (EmployeeAddDto employeeAddDto)
        {
            try
            {
               await employeeService.AddUserAndEmployee(employeeAddDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                await employeeService.Delete(id);
                return Ok("Deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(long id , EmployeeupdateDto employeeupdateDto)
        {
            try
            {
                await employeeService.Update(id, employeeupdateDto);
                return Ok("update employee is success");
            }
           
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
