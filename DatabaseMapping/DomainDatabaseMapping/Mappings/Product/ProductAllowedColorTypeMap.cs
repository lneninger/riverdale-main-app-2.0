using DomainModel.Product;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings.Product
{
    public class ProductAllowedColorTypeMap : BaseAbstractMap, IEntityTypeConfiguration<ProductAllowedColorType>
    {

        public ProductAllowedColorTypeMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<ProductAllowedColorType> builder)
        {
            builder.ToTable("ProductAllowedColorType", SCHEMAS.PRODUCT);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd()
                ;

            builder.HasOne(t => t.ProductColorType)
                .WithMany()
                .HasForeignKey(t => t.ProductColorTypeId)
                ;

            builder.HasOne(t => t.Product)
                .WithMany(t => t.ProductAllowedColorTypes)
                .HasForeignKey(t => t.ProductId)
                ;
        }
    }
}
