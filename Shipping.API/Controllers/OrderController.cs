using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Services.Dtos;
using Shipping.Services.IServices;

namespace Shipping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService _orderService)
        {
            orderService = _orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetAll()
        {
            var orders = await orderService.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<OrderReadDto>> GetById(Guid id)
        {
            var order = await orderService.GetByIdAsync(id);
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult> Add(OrderAddDto order)
        {
            if (order == null)
                return BadRequest("Order is Null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await orderService.AddAsync(order);

            return CreatedAtAction(nameof(order), new { id = order.Id }, order);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Guid id, OrderUpdateDto order)
        {
            if (id != order.Id)
                return BadRequest("Order is Null.");
 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var oldOrder = await orderService.GetByIdAsync(id);
            if (oldOrder == null)
                return NotFound();
            
            await orderService.UpdateAsync(order, id);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            var order = await orderService.GetByIdAsync(id);
            if (order == null)
                return NotFound();
            
            await orderService.DeleteAsync(id);
            return NoContent();
        }
    }
}
