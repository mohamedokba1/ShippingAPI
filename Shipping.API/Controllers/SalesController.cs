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
        [Route("{id}")]
        public async Task<ActionResult<SalesReadDtos>> GetSaleById(long id)
        {
            return Ok(await _salesService.GetSaleByIdAsync(id));

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteSale(long id)
        {
            await _salesService.DeleteAsync(id);
            return NoContent();
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateSale(long id, SalesUpdateDtos sale)
        {
            await _salesService.UpdateAsync(id, sale);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> AddSale(AddSalesDto sale)
        {
            await _salesService.AddAsync(sale);
            return CreatedAtAction(nameof(GetSaleById), new { id = sale.SalesRepresentative_Id }, sale);
        }

    }
}
