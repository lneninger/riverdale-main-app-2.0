using DomainModel.Product;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDatabaseMapping.Mappings.Product
{
    public class FlowerProductCategoryMap : BaseAbstractMap, IEntityTypeConfiguration<ProductCategory>
    {

        public FlowerProductCategoryMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategory", SCHEMAS.PRODUCT);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasMaxLength(20);

            builder.Property(t => t.Name)
                .HasMaxLength(30)
                ;

            builder.HasMany(t => t.Flowers)
                .WithOne(t => t.ProductCategory)
                .HasForeignKey(c => c.ProductCategoryId)
                ;

            builder.HasMany(t => t.Sizes)
                .WithOne(t => t.ProductCategory)
                .HasForeignKey(c => c.ProductCategoryId)
                ;
        }
        }
}
