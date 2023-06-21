using Microsoft.AspNetCore.Mvc.Filters;

namespace Shipping.API.ErrorHandling;

public class GlobalErrorHandling : ExceptionFilterAttribute
{
    private readonly ILogger<GlobalErrorHandling> _logger;

    public GlobalErrorHandling(ILogger<GlobalErrorHandling> logger)
    {
        _logger = logger;
    }

    public override void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception, "Unhandled exception occured.");
        context.ExceptionHandled = true;
    }
}
