using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Services.Dtos;
using Shipping.Services.IServices;
using Shipping.Services.Services;

namespace Shipping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService _permissionService;
        public PermissionsController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermissionDto>>> GetAll()
        {
            var privellages = await _permissionService.Getall();
            return Ok(privellages);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PermissionDto>> GetById(int id)
        {
            var privellage = await _permissionService.GetByid(id);
            if (privellage == null)
                return NotFound();
            return Ok(privellage);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PermissionAddDto privellageaddDto)
        {
           return BadRequest();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(int id,PermissionUpdateDto privellagedto)
        {
            try
            {
                await _permissionService.Update(id, privellagedto);
                return Ok("update privilege is sucees");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _permissionService.Delete(id);
                return Ok("Seleted successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
