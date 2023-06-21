using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Services.Dtos;
using Shipping.Services.IServices;
using Shipping.Services.Services;

namespace Shipping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovermentController : ControllerBase
    {
        private readonly IGovernmentService governmentService;

        public GovermentController(IGovernmentService governmentService)
        {
            this.governmentService = governmentService;
        }


        [HttpGet]
        [Route("Getall")]
        public async Task<ActionResult<IEnumerable<GovermentReadDto>>> Getall()
        {
            return  Ok(await governmentService.Getall());
                
        }


        [HttpGet]
        [Route("GetById/{id}")]

        public async Task<ActionResult<GovermentReadDto>> GetById(int id)
        {
            GovermentReadDto? govermentReadDto = await governmentService.GetByid(id);
            if (govermentReadDto == null)
            {
                return NotFound();
            }
            return Ok(govermentReadDto);
        }


        [HttpPost]
        [Route("Add")]

        public async Task<ActionResult> Add(GovermentAddDto govermentAddDto)
        {
            try
            {
                await governmentService.Add(govermentAddDto);
                return NoContent();
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
            await governmentService.Delete(id);
            return NoContent();
        }

        [HttpPut]
        [Route("update/{id}")]

        public async Task<ActionResult> Update(int id, GovermentUpdateDto govermentUpdateDto)
        {
            await governmentService.Update(id, govermentUpdateDto);
            return NoContent();
        }

    }
}

