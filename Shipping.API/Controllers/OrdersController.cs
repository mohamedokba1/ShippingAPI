using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult<OrderResponseDto>> GetById(long id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult> Add(OrderAddDto order, [FromHeader] string userEmail)
        {
            List<ValidationResult>? errors =  await _orderService.AddOrderAsync(order, userEmail);
            if(errors?.Count ==0)
            {
                return Ok(order);
            }
            else
                return BadRequest(errors);
        }

        [HttpPut]
        [Route("{id}")]
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
        public async Task<ActionResult> Delete(long id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();
            
            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }

        [HttpGet("paginated")]
        public async Task<ActionResult<PaginationResponse<OrderResponseDto>>> GetOrder([FromQuery] PaginationParameters paginationParameters)
        {
            var orderes = _orderService.GetOrderesPaginated();

            int totalRecords = await orderes.CountAsync();

            List<OrderResponseDto>? listOfOrderes = await orderes
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .ToListAsync();
            PaginationResponse<OrderResponseDto> result =
                new PaginationResponse<OrderResponseDto>()
                {
                    Data = listOfOrderes,
                    PageNo = paginationParameters.PageNumber,
                    PageSize = paginationParameters.PageSize,
                    TotalRecords = totalRecords
                };
            return Ok(result);
        }
    }
}
