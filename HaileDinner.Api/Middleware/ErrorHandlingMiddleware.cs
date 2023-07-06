

using System.Net;
using System.Text.Json;

namespace HaileDinner.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
       
        public async Task Invok(HttpContext context)
        {
            try
            {
                await _next(context);
            }catch(Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("error occured" );
            }
        }

        public static Task HandleExceptionAsync(HttpContext httpContext,Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(new { error = "error occured while loading" });
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)code;
            return httpContext.Response.WriteAsync(result);
        }
    }
}
