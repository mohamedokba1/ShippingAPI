using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
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
