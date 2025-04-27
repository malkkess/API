using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presis.Data;
using Presis.Repositories;

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

            return Services;
        }

    }
}
