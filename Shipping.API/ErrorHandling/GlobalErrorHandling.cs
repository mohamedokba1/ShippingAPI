namespace Shipping.API.ErrorHandling;

public class GlobalErrorHandling
{
    private readonly RequestDelegate _next;
    public GlobalErrorHandling(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync(ex.Message);
        }
    }
}
