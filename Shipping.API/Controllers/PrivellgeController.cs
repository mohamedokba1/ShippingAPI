using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Services.Dtos;
using Shipping.Services.IServices;

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
        public async Task<ActionResult<IEnumerable<PrivellageDto>>> GetAll()
        {
            var privellages = await privellageService.GetAllAsync();
            return Ok(privellages);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<OrderReadDto>> GetById(long id)
        {
            var privellage = await privellageService.GetByIdAsync(id);
            if (privellage == null)
                return NotFound();
            return Ok(privellage);
        }

        [HttpPost]
        public async Task<ActionResult> Add(PrivellageDto privellage)
        {
            if (privellage == null)
                return BadRequest("Privellage is Null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await privellageService.AddAsync(privellage);

            return CreatedAtAction(nameof(privellage), new { id = privellage.Id }, privellage);
        }

        [HttpPut]
        public async Task<ActionResult> Update(long id, PrivellageDto privellage)
        {
            if (id != privellage.Id)
                return BadRequest("Privellage is Null.");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var oldPrivellge = await privellageService.GetByIdAsync(id);
            if (oldPrivellge == null)
                return NotFound();

            await privellageService.UpdateAsync(oldPrivellge, id);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(long id)
        {
            var privellage = await privellageService.GetByIdAsync(id);
            if (privellage == null)
                return NotFound();

            await privellageService.DeleteAsync(id);
            return NoContent();
        }
    }
}
