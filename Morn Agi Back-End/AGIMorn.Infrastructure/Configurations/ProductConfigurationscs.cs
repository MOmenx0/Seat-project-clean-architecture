using AGI.Morn.Domain.Entities;
using AGI.Morn.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGI.Morn.Infrastructure.Configurations
{
    public class ProductConfigurationscs : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p=>p.Name).IsRequired();
            builder.Property(p=> p.Description).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal");
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.HasOne(P => P.ProductPrand).WithMany().HasForeignKey(P => P.ProudctPrandId);
            builder.HasOne(p => p.productType).WithMany().HasForeignKey(p => p.ProductTypeId);
        }
    }
}
