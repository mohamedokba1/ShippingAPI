using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Services.Dtos;
using System.Net.Sockets;

namespace Shipping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService) 
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityReadDto>>> GetAllCities()
        {
            var cities=await _cityService.GetAllAsync();
            return Ok(cities);
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
