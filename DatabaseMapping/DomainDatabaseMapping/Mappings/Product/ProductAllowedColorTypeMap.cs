using DomainModel.Product;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings.Product
{
    public class ProductAllowedColorTypeMap : BaseAbstractMap, IEntityTypeConfiguration<ProductCategoryAllowedColorType>
    {

        public ProductAllowedColorTypeMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<ProductCategoryAllowedColorType> builder)
        {
            builder.ToTable("ProductAllowedColorType", SCHEMAS.PRODUCT);
            builder.HasKey(t => t.TempId);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd()
                ;

            builder.HasOne(t => t.ProductColorType)
                .WithMany()
                .HasForeignKey(t => t.ProductColorTypeId)
                ;

            builder.HasOne(t => t.ProductCategory)
                .WithMany(t => t.AllowedColorTypes)
                .HasForeignKey(t => t.ProductCategoryId)
                ;
        }
    }
}
