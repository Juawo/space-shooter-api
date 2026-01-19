namespace SpaceShooterApi.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private readonly IWebHostEnvironment _env;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IWebHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error{Message}", ex.Message);
            var statusCode = ex switch
            {
                ArgumentNullException => StatusCodes.Status400BadRequest,
                KeyNotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };
            
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";
            
            var isDevelopment = _env.IsDevelopment();
            var details = isDevelopment ? ex.StackTrace : "";
            var errorResponse = new
            {
                Message = "Unexpected error.",
                Details = details
            };
            await context.Response.WriteAsJsonAsync(errorResponse).ConfigureAwait(false);
        }
    }
}