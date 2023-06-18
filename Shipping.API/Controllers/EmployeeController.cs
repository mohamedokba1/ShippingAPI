using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Services.Dtos;
using Shipping.Services.IServices;

namespace Shipping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        [Route("Getall")]
        public  async Task<ActionResult<IEnumerable<EmployeeReadDto>>> Getall()
        {
            return Ok(await employeeService.Getall());
           
        }


        [HttpGet]
        [Route("GetById/{id}")]

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
        [Route("Add")]

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
        [Route("Delete")]

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
        [Route("update/{id}")]

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
