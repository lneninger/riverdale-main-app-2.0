using DomainModel.Product;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDatabaseMapping.Mappings.Product
{
    public class ProductMediaMap : BaseAbstractMap, IEntityTypeConfiguration<ProductMedia>
    {

        public ProductMediaMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<ProductMedia> builder)
        {

            builder.ToTable("ProductMedia", SCHEMAS.PRODUCT);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasMaxLength(4);

            builder.HasOne(t => t.Product)
                .WithMany(t => t.ProductMedia)
                .HasForeignKey(t => t.ProductId)
                ;


            builder.HasOne(t => t.FileRepository)
                .WithMany()
                .HasForeignKey(t => t.FileRepositoryId)
                ;
        }
    }
}
