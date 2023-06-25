using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shipping.API.PoliciesProvider;
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
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Authorize(Policy = "permission.orders.read")]
        //[RequireClaim("permission.orders.read")]
        public async Task<ActionResult<IEnumerable<OrderResponseDto>>> GetAll([FromHeader] string userEmail)
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
        [Authorize("Admin")]
        public async Task<ActionResult<OrderResponseDto>> GetById(long id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        [HttpPost]
        [RequireClaim("permission.orders.add")]
        public async Task<ActionResult> Add(OrderAddDto order, [FromHeader] string userEmail)
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
        [RequireClaim("permission.orders.update")]
        public async Task<ActionResult> Update(long id, OrderUpdateDto order)
        {
            var oldOrder = await _orderService.GetOrderByIdAsync(id);
            if (oldOrder != null)
            {
                var errors = await _orderService.UpdateOrderAsync(id, order);
                if (errors?.Count == 0)
                    return NoContent();
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        [RequireClaim("permission.orders.delete")]
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
