using System.Text.Json;
using Shared.ErrorModels;

namespace E_Commerce.Web.CustomMiddleWares
{
    public class CustomExcepMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExcepMiddleWare> logger;

        public CustomExcepMiddleWare(RequestDelegate Next , ILogger<CustomExcepMiddleWare>logger)
        {
            _next = Next;
            this.logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch(Exception ex)
            {
                logger.LogError(ex,"Something Went Wrong");
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var Response = new ErrorToReturn()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    ErrorMessage = ex.Message
                };
                
                await httpContext.Response.WriteAsJsonAsync(Response);

            }

        }
    }
}
