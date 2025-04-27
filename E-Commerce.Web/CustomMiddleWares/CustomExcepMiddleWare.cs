using System.Text.Json;
using DomainLayer.Exceptions;
using Shared.ErrorModels;

namespace E_Commerce.Web.CustomMiddleWares
{
    public class CustomExcepMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExcepMiddleWare> logger;

        public CustomExcepMiddleWare(RequestDelegate Next, ILogger<CustomExcepMiddleWare> logger)
        {
            _next = Next;
            this.logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
                await HandleEndPointExecption(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Something Went Wrong");
                await HandleExceptionAsync(httpContext, ex);

            }

        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.StatusCode = ex switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };


            var Response = new ErrorToReturn()
            {
                StatusCode = httpContext.Response.StatusCode,
                ErrorMessage = ex.Message
            };

            await httpContext.Response.WriteAsJsonAsync(Response);
        }

        private static async Task HandleEndPointExecption(HttpContext httpContext)
        {
            if (httpContext.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                var Response = new ErrorToReturn()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = $"End Point {httpContext.Request.Path} is Not Found"
                };
                await httpContext.Response.WriteAsJsonAsync(Response);

            }
        }
    }
}
