using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Presis.Data;

namespace Presis
{
    public class DataSeeding(StoreDbContext dbcontext) : IDataSeeding
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
    }
}
