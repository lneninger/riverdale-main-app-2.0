using DomainModel.Product;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDatabaseMapping.Mappings.Product
{
    public class ProductTypeMap : BaseAbstractMap, IEntityTypeConfiguration<ProductType>
    {

        public ProductTypeMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<ProductType> builder)
        {

            builder.ToTable("ProductType", SCHEMAS.PRODUCT);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasMaxLength(4);

            builder.Property(t => t.Name)
               .HasMaxLength(25)
               .IsRequired(true);

            builder.Property(t => t.Description)
               .HasMaxLength(100)
               .IsRequired(true);


            // Seed
            builder.HasData(new ProductType { Id = "FLW", Name = "Flower", Description = "Raw Flower", CreatedAt = DateTime.UtcNow, CreatedBy = "Seed" });
            builder.HasData(new ProductType { Id = "COMP", Name = "Composition", Description = "Multiple Product Composition. Kit", CreatedAt = DateTime.UtcNow, CreatedBy = "Seed" });
            builder.HasData(new ProductType { Id = "HARD", Name = "Hardgood", Description = "Hardgood", CreatedAt = DateTime.UtcNow, CreatedBy = "Seed" });

        }
    }
}
