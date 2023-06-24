using Microsoft.AspNetCore.Mvc;
using Shipping.Services.Dtos;
using Shipping.Services.Dtos.SalesDtos;
using Shipping.Services.IServices;

namespace Shipping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;
        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesReadDtos>>> GetAllSales()
        {
            return Ok(await _salesService.GetAllSalesAsync());
        }
        [HttpGet]
        [Route("id")]
        public async Task<ActionResult<SalesReadDtos>> GetSaleById(long id)
        {
            return Ok(await _salesService.GetSaleByIdAsync(id));

        }
        [HttpGet]
        [Route("{email}")]
        public async Task<ActionResult<long>> GetSalesRepresentativeIdByEmail(string email)
        {
            try
            {
                var salesRepresentativeId = await _salesService.GetSalesRepresentativeIdByEmail(email);
                return salesRepresentativeId;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteSale(long id)
        {
            try
            {
                await _salesService.DeleteAsync(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateSale(long id, SalesUpdateDtos sale)
        {
            try
            {
                await _salesService.UpdateAsync(id, sale);
                return NoContent();
            }
            catch(Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
            
           
        }

        [HttpPost]
        public async Task<ActionResult> AddSale(AddSalesDto sale)
        {
            try
            {
                await _salesService.AddUserAndSales(sale);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

    }
}
