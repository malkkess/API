using DomainLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using Presis;
using Service.Profiles;
using Presis.Data;
using Presis.Repositories;
using ServiceAbsrt;
using Service;
using E_Commerce.Web.CustomMiddleWares;
using Microsoft.AspNetCore.Mvc;
using Shared.ErrorModels;
using E_Commerce.Web.Factories;
using E_Commerce.Web.Extentsions;
using DomainLayer.Models.IdentityModule;
using Microsoft.AspNetCore.Identity;
using Presis.Identity;
namespace E_Commerce.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddSwaggerServices();
            builder.Services.AddInfastructure(builder.Configuration);
            builder.Services.AddApplicationServices();
            builder.Services.AddWebApplicationServices();
           
            var app = builder.Build();

            await app.SeedDataBaseAsync();
            //app.Use(async(RequestContext , NextMiddleWare) =>
            //{
            //    Console.WriteLine("Request Under Processing");
            //    await NextMiddleWare.Invoke();
            //    Console.WriteLine("Waiting Response");
            //    Console.WriteLine(RequestContext.Response.Body);

            //});
            app.UseCustomerExceptionMiddleWare();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
                app.UseSwaggerMiddleWares();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
