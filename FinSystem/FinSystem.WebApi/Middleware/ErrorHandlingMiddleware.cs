using System.Net;
using System.Text.Json;

namespace FinSystem.WebApi.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, _logger);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger logger)
        {
            // Generate a unique error ID for tracking, to be in a database or file etc...
            var errorId = Guid.NewGuid();

            logger.LogError(exception, "An unhandled exception occurred. Error ID: {ErrorId}", errorId);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var response = new
            {
                Success = false,
                StatusCode = context.Response.StatusCode,
                Message = $"An unexpected error occurred with ID {errorId}. Please contact IT.",
                Data = (object)null
            };

            var jsonResponse = JsonSerializer.Serialize(response);

            return context.Response.WriteAsync(jsonResponse);
        }
    }
}
