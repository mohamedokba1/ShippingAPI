using Microsoft.AspNetCore.Mvc;
using Shipping.Services.Dtos;
using Shipping.Services.IServices;
using System.ComponentModel.DataAnnotations;

namespace Shipping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ITraderService _traderService;
        public OrdersController(
            IOrderService orderService,
            ITraderService traderService)
        {
            _orderService = orderService;
            _traderService = traderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponseDto>>> GetAll(string userEmail)
        {
            var orders = await _orderService.GetAllOrdersAsync(userEmail);
            if (orders == null)
            {
                return BadRequest("Trader not found");
            }
            return Ok(orders);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<OrderResponseDto>> GetById(long id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult> Add(OrderAddDto order, string userEmail)
        {
            List<ValidationResult>? errors =  await _orderService.AddOrderAsync(order, userEmail);
            if(errors?.Count ==0)
            {
                return Ok(order);
            }
            else
                return BadRequest();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(long id, OrderUpdateDto order)
        {
            var oldOrder = await _orderService.GetOrderByIdAsync(id);
            if (oldOrder != null)
                await _orderService.UpdateOrderAsync(id, order);
            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();
            
            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
