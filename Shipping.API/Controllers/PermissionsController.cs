using Microsoft.AspNetCore.Mvc;
using Shipping.Services.Dtos;
using Shipping.Services.IServices;

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
        public async Task<ActionResult<IEnumerable<PermissionResponseDto>>> GetAll()
        {
            var privellages = await _permissionService.Getall();
            return Ok(privellages);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PermissionResponseDto>> GetById(string id)
        {
            var permission = await _permissionService.GetByid(id);
            if (permission == null)
                return NotFound();
            return Ok(permission);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PermissionAddDto permissionAddDto)
        {
            
            await _permissionService.Add(permissionAddDto);
            return Created("new permission added successfully", permissionAddDto);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(string id,PermissionUpdateDto permissionUpdateDto)
        {
            bool result = await _permissionService.Update(id, permissionUpdateDto);
            if (result)
                return NoContent();
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
           bool result =  await _permissionService.Delete(id);
            if(result)
                return NoContent();
            return BadRequest();
        }
    }
}
