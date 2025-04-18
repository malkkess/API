﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presis.Data.Config
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p=>p.productBrand).WithMany().HasForeignKey(p=>p.BrandId);
            builder.HasOne(p => p.productType).WithMany().HasForeignKey(p => p.TypeId);
            builder.Property(p => p.Price).HasColumnType("decimal(10,2)");
        }
    }
}
