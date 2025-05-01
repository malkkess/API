using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DomainLayer.Contracts;
using DomainLayer.Models;
using DomainLayer.Models.IdentityModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Presis.Data;
using Presis.Identity;

namespace Presis
{
    public class DataSeeding(StoreDbContext dbcontext, UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager , StoreIdentityDbContext identityDbContext) : IDataSeeding
    {
        public async Task DataseedAsync()
        {
            try
            {
                var PendingMigrations = await dbcontext.Database.GetPendingMigrationsAsync();
                if (PendingMigrations.Any())
                {
                    await dbcontext.Database.MigrateAsync();
                }
                if (dbcontext.ProductBrands.Any())
                {
                    var ProductBrandData = File.OpenRead(@"..\Presis\Data\DataSeedData\brands.json");
                    var ProductBrands = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(ProductBrandData);
                    if (ProductBrands is not null && ProductBrands.Any())
                        await dbcontext.ProductBrands.AddRangeAsync(ProductBrands);
                }
                if (dbcontext.productTypes.Any())
                {
                    var ProductTypeData = File.OpenRead(@"..\Presis\Data\DataSeedData\types.json");
                    var ProductTypes = await JsonSerializer.DeserializeAsync<List<ProductType>>(ProductTypeData);
                    if (ProductTypes is not null && ProductTypes.Any())
                        await dbcontext.productTypes.AddRangeAsync(ProductTypes);
                }
                if (dbcontext.Products.Any())
                {
                    var ProductData = File.OpenRead(@"..\Presis\Data\DataSeedData\products.json");
                    var Products = await JsonSerializer.DeserializeAsync<List<Product>>(ProductData);
                    if (Products is not null && Products.Any())
                        await dbcontext.Products.AddRangeAsync(Products);
                }
                await dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task IdentityDataSeedAsync()
        {
            try
            {
                if (!roleManager.Roles.Any())
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                    await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
                }
                if (!userManager.Users.Any())
                {
                    var User01 = new ApplicationUser()
                    {
                        Email = "Mohamed@gmail.com",
                        DisplayName = "Moahmed Tarek",
                        PhoneNumber = "0123456789",
                        UserName = "MohamedTarek"
                    };
                    var User02 = new ApplicationUser()
                    {
                        Email = "Salma@gmail.com",
                        DisplayName = "Salma Mohamed",
                        PhoneNumber = "0123456789",
                        UserName = "SalmaMohamed"
                    };

                    await userManager.CreateAsync(User01, "P@ssw0rd");
                    await userManager.CreateAsync(User02, "P@ssw0rd");

                    await userManager.AddToRoleAsync(User01, "Admin");
                    await userManager.AddToRoleAsync(User02, "SuperAdmin");

                }

                await identityDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }

        }
    }
}

