using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Shipping.API.Controllers
{
    [Route("/error")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exceptionMessage = exceptionDetails?.Error?.Message ?? string.Empty;
            return StatusCode(500, new {Message = exceptionMessage});
        }
    }
}
