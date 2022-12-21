namespace Lenta.Api.Middleware;

public static class ExceptionMiddleware
{
    public static void UseValidationException(this IApplicationBuilder app)
    {
        app.Use(async (context, next) =>
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(new { ex.Message });
            }
        });
    }
}