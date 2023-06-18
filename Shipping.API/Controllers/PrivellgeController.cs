using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Services.Dtos;
using Shipping.Services.IServices;
using Shipping.Services.Services;

namespace Shipping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivellgeController : ControllerBase
    {
        private readonly IPrivellageService privellageService;
        public PrivellgeController(IPrivellageService _privellageService)
        {
            privellageService = _privellageService;
        }

        [HttpGet]
        [Route("Getall")]

        public async Task<ActionResult<IEnumerable<PrivellageDto>>> GetAll()
        {
            var privellages = await privellageService.Getall();
            return Ok(privellages);
        }

        [HttpGet]
        [Route("GetById/{id}")]

        public async Task<ActionResult<PrivellageDto>> GetById(int id)
        {
            var privellage = await privellageService.GetByid(id);
            if (privellage == null)
                return NotFound();
            return Ok(privellage);
        }

        [HttpPost]
        [Route("Add")]

        public async Task<ActionResult> Add(PrivilegeAddDto privellageaddDto)
        {
            try
            {
                await privellageService.Add(privellageaddDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update/{id}")]


        public async Task<ActionResult> Update(int id,PrivllageUpdateDto privellagedto)
        {
            try
            {
                await privellageService.Update(id, privellagedto);
                return Ok("update privilege is sucees");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await privellageService.Delete(id);
                return Ok("Seleted successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
