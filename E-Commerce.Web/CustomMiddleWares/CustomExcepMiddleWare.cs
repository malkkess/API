﻿using System.Text.Json;
using DomainLayer.Exceptions;
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
                httpContext.Response.StatusCode = ex switch
                {
                    NotFoundException=>StatusCodes.Status404NotFound,
                    _ =>StatusCodes.Status500InternalServerError
                };
                

                var Response = new ErrorToReturn()
                {
                    StatusCode = httpContext.Response.StatusCode,
                    ErrorMessage = ex.Message
                };
                
                await httpContext.Response.WriteAsJsonAsync(Response);

            }

        }
    }
}
