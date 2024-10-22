using System.Net;
using uit_learn_backend.Constant;

namespace uit_learn_backend.Core
{
    public class CustomExceptMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomExceptMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
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
