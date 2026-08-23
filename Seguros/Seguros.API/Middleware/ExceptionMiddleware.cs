using Seguros.API.Errors;
using Seguros.Application.Exceptions;

namespace Seguros.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                int statusCode = ex switch
                {
                   NotFoundException => StatusCodes.Status404NotFound,
                   BadRequestException => StatusCodes.Status400BadRequest,
                   UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                    _ => StatusCodes.Status500InternalServerError
                };

                httpContext.Response.StatusCode = statusCode;
                httpContext.Response.ContentType = "application/json";
                var response = _env.IsDevelopment()
                    ? new ApiException(statusCode.ToString(), ex.Message, ex.StackTrace?.ToString())
                    : new ApiException(statusCode.ToString(), ex.Message, "Internal Server Error");

                var options = new System.Text.Json.JsonSerializerOptions { PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase };
                var json = System.Text.Json.JsonSerializer.Serialize(response, options);
                await httpContext.Response.WriteAsJsonAsync(response);
            }
        }   
    }
}
