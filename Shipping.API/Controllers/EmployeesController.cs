using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
               await employeeService.Add(employeeAddDto);
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
