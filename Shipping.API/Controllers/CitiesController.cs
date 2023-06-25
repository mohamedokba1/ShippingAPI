using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shipping.Services.Dtos;
using Shipping.Services.IServices;


namespace Shipping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CitiesController(ICityService cityService) 
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityReadDto>>> GetAllCities()
        {
            var cities=await _cityService.GetAllAsync();
            return Ok(cities);
        }
        [HttpGet("paginated")]
        public async Task<ActionResult<PaginationResponse<CityReadDto>>> GetCities([FromQuery] PaginationParameters paginationParameters)
        {
            var cities = _cityService.GetCitiesPaginated();

            int totalRecords = await cities.CountAsync();

            List<CityReadDto>? listOfCities = await cities
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .ToListAsync();
            PaginationResponse<CityReadDto> result =
                new PaginationResponse<CityReadDto>()
                {
                    Data = listOfCities,
                    PageNo = paginationParameters.PageNumber,
                    PageSize = paginationParameters.PageSize,
                    TotalRecords = totalRecords
                };
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CityReadDto>> GetCity(int id)
        {
            var city = await _cityService.GetByIdAsync(id);
            if(city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }
        [HttpGet("government/{governmentName}")]
        public async Task<ActionResult<IEnumerable<CityReadDto>>> GetCitiesByGovernmentName(string governmentName)
        {
            var cities = await _cityService.GetCitiesByGovernmentNameAsync(governmentName);
            return Ok(cities);
        }
        [HttpPost]
        public async Task<ActionResult> AddCity(CityAddDto city)
        {
            if (city == null)
            {
                return BadRequest("City is Null.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _cityService.AddAsync(city);

            return CreatedAtAction(nameof(GetCity), new { id = city.CityId }, city);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateCity(int id, CityUpdateDto city)
        {
            if (id != city.CityId)
            {
                return BadRequest("City is Null.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ExistingCity = await _cityService.GetByIdAsync(id);
            if(ExistingCity == null)
            {
                return NotFound();
            }
            await _cityService.UpdateAsync(city,id);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteCity(int id)
        {
            var ExistingCity = await _cityService.GetByIdAsync(id);
            if (ExistingCity == null)
            {
                return NotFound();
            }
            await _cityService.DeleteAsync(id);
            return NoContent();
        }
    }
}
