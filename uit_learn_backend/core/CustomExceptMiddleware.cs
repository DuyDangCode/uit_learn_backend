using System.Net;

namespace uit_learn_backend.core
{
    public class CustomExceptMiddleware
    {
        private const string ErrorMessage = "Something went wrong!!!";
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
                StatusCode = httpContext.Response.StatusCode,
                Message = ErrorMessage
            }.ToString());
        }
    }
}
