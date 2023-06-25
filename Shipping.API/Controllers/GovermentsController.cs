using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shipping.API.PoliciesProvider;
using Shipping.Services.Dtos;
using Shipping.Services.IServices;
using Shipping.Services.Services;

namespace Shipping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovermentsController : ControllerBase
    {
        private readonly IGovernmentService governmentService;

        public GovermentsController(IGovernmentService governmentService)
        {
            this.governmentService = governmentService;
        }


        [HttpGet]
        //[RequireClaim("permission.goverment.read")]
        public async Task<ActionResult<IEnumerable<GovermentReadDto>>> Getall()
        {
            return  Ok(await governmentService.Getall());   
        }
        [HttpGet("paginated")]
        public async Task<ActionResult<PaginationResponse<GovermentReadDto>>> GetGovernment([FromQuery] PaginationParameters paginationParameters)
        {
            var governments = governmentService.GetGovernmentsPaginated();

            int totalRecords = await governments.CountAsync();

            List<GovermentReadDto>? listOfGovernments = await governments
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .ToListAsync();
            PaginationResponse<GovermentReadDto> result =
                new PaginationResponse<GovermentReadDto>()
                {
                    Data = listOfGovernments,
                    PageNo = paginationParameters.PageNumber,
                    PageSize = paginationParameters.PageSize,
                    TotalRecords = totalRecords
                };
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
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
        
        //[RequireClaim("permission.goverment.add")]
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
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await governmentService.Delete(id);
            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(int id, GovermentUpdateDto govermentUpdateDto)
        {
            await governmentService.Update(id, govermentUpdateDto);
            return NoContent();
        }

    }
}