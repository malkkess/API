using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Contracts;
using DomainLayer.Models.IdentityModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presis.Data;
using Presis.Identity;
using Presis.Repositories;
using StackExchange.Redis;

namespace Presis
{
    public static class InfastructureServicesRegistration
    {
        public static IServiceCollection AddInfastructure(this IServiceCollection Services , IConfiguration confg)
        {
            Services.AddDbContext<StoreDbContext>(opt =>
            {
                opt.UseSqlServer(confg.GetConnectionString("DefaultConnection"));
            });
            Services.AddScoped<IDataSeeding, DataSeeding>();
            Services.AddScoped<IUnitOfWork, UnitOfWok>();
            Services.AddScoped<IBasketRepo, BasketRepo>();
            Services.AddSingleton<IConnectionMultiplexer>((_) =>
            {
               return  ConnectionMultiplexer.Connect(confg.GetConnectionString("RediusConnectionString"));
            });
            Services.AddDbContext<StoreIdentityDbContext>(Options =>
            {
                Options.UseSqlServer(confg.GetConnectionString("IdentityConnection"));
            });
            Services.AddIdentityCore<ApplicationUser>()
                .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<StoreIdentityDbContext>();

            return Services;
        }

    }
}
