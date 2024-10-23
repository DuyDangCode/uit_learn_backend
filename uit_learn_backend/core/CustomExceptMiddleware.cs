using System.Diagnostics;
using System.Net;
using uit_learn_backend.Constant;

namespace uit_learn_backend.Core
{
    public class CustomExceptMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger? _logger;
        public CustomExceptMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                //_logger.Log(LogLevel.Information,
                //            "UIT_LEARN::Info::",
                //            httpContext.Request.Path.Value,
                //            httpContext.Request.Method,
                //            httpContext.Request.QueryString.Value,
                //            httpContext.Request.Headers["Authorization"]);
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\n\n\tError::" + ex.Message + "\n\n");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await httpContext.Response.WriteAsync(new ErrorDetail()
            {
                StatusCode = StatusCode.InternalServerError,
                Message = MessageStatusCode.InternalServerError
            }.ToString());
        }
    }
}
