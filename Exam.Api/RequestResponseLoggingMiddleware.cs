using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Exam.Api
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestResponseLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestResponseLoggingMiddleware>();
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation($"Request: {await FormatRequest(httpContext.Request)}");

            var originalBodyStream = httpContext.Response.Body;
            using (var responseBody = new MemoryStream())
            {
                httpContext.Response.Body = responseBody;

                await _next(httpContext);

                _logger.LogInformation($"ResponseBody: {await FormatResponse(httpContext.Response)}");
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }
        private async Task<string> FormatRequest(HttpRequest request)
        {
            request.EnableBuffering();

            using (var reader = new StreamReader(request.Body, Encoding.UTF8, false, 1024, true))
            {
                var body = await reader.ReadToEndAsync();

                request.Body.Seek(0, SeekOrigin.Begin);
                return $"RequestBody: {body}";
            }
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var body = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);
            return $"ResponseBody: {body}";
        }
    }

    public static class RequestResponseLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestResponseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestResponseLoggingMiddleware>();
        }
    }
}
