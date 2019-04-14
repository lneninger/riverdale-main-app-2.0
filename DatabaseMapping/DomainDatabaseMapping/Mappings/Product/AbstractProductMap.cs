using DomainModel.Product;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings.Product
{
    public class AbstractProductMap : BaseAbstractMap, IEntityTypeConfiguration<AbstractProduct>
    {

        public AbstractProductMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<AbstractProduct> builder)
        {
            builder.ToTable("Product", SCHEMAS.PRODUCT);
            builder.HasKey(t => t.Id);

            builder
            .HasDiscriminator<string>("ProductTypeId")
            .HasValue<FlowerProduct>("FLW")
            .HasValue<CompositionProduct>("COMP")
            .HasValue<HardgoodProduct>("HARD");

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd()
                ;

            builder.Ignore(t => t.ProductTypeEnum);
            builder.Ignore(t => t.ProductCategoryId);

            builder.Property(t => t.ProductCategoryId)
                .IsRequired(false);

            builder.HasOne(t => t.ProductType)
                .WithMany(t => t.Products)
                .HasForeignKey(t => t.ProductTypeId)
                ;

     //       builder.HasOne(c => c.ProductCategory)
     //.WithMany(p => p.Products)
     //.HasForeignKey(c => c.ProductCategoryId)
     //;
        }
    }
}
