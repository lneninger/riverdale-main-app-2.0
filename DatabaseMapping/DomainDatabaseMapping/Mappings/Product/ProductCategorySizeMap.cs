using DomainModel.Product;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings.Product
{
    public class ProductCategorySizeMap : BaseAbstractMap, IEntityTypeConfiguration<ProductCategoryAllowedSize>
    {

        public ProductCategorySizeMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<ProductCategoryAllowedSize> builder)
        {
            builder.ToTable("FlowerProductCategoryGrade", SCHEMAS.PRODUCT);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasMaxLength(4);

            builder.HasOne(t => t.ProductCategory)
                .WithMany(t => t.Sizes)
                .HasForeignKey(t => t.ProductCategoryId)
                ;

            
        }
    }
}
