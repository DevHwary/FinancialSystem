using System.Text.Json;

namespace FinSystem.WebApi.Middleware
{
    public class ResponseTemplateMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseTemplateMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;

            using var memoryStream = new MemoryStream();
            context.Response.Body = memoryStream;

            try
            {
                // Continue through the pipeline
                await _next(context);

                if (context.Response.StatusCode < 500)
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    var originalResponse = await new StreamReader(memoryStream).ReadToEndAsync();

                    var wrappedResponse = new
                    {
                        Success = true,
                        StatusCode = context.Response.StatusCode,
                        Data = JsonSerializer.Deserialize<object>(originalResponse)
                    };

                    context.Response.Body = originalBodyStream;
                    context.Response.ContentType = "application/json";
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(wrappedResponse));
                }
                else
                {
                    // If it's an error response, just copy the original content back
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    await memoryStream.CopyToAsync(originalBodyStream);
                }
            }
            finally
            {
                // Restore the original response body stream
                context.Response.Body = originalBodyStream;
            }
        }
    }
}
