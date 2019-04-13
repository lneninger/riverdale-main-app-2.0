using DomainModel.Product;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings.Product
{
    public class ProductCategorySizeMap : BaseAbstractMap, IEntityTypeConfiguration<ProductCategorySize>
    {

        public ProductCategorySizeMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<ProductCategorySize> builder)
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
