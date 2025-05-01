using DomainLayer.Contracts;
using E_Commerce.Web.CustomMiddleWares;

namespace E_Commerce.Web.Extentsions
{
    public static class WebApplicationRegisteration
    {
        public static async Task  SeedDataBaseAsync(this WebApplication app)
        {
            using var scoope = app.Services.CreateScope();
            var objData = scoope.ServiceProvider.GetRequiredService<IDataSeeding>();

            await objData.DataseedAsync();
            await objData.IdentityDataSeedAsync();
        }
        public static IApplicationBuilder UseCustomerExceptionMiddleWare(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExcepMiddleWare>();

            return app;
        }
        public static IApplicationBuilder UseSwaggerMiddleWares(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            return app;
        }

    }
}
