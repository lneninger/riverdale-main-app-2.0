using DomainModel.Product;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDatabaseMapping.Mappings.Product
{
    public class BasicProductAliasMap : BaseAbstractMap, IEntityTypeConfiguration<BasicProductAlias>
    {

        public BasicProductAliasMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<BasicProductAlias> builder)
        {
            builder.ToTable("BasicProductAlias", SCHEMAS.PRODUCT);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd()
                ;

            builder.Property(t => t.Name)
                .HasMaxLength(150)
                .IsRequired();

            builder.HasOne(t => t.Product)
                 .WithMany()
                 .HasForeignKey(t => t.ProductId)
                 .OnDelete(DeleteBehavior.Restrict)
                 ;

            builder.HasOne(t => t.ColorType)
                .WithMany()
                .HasForeignKey(t => t.ColorTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                ;

            builder.HasOne(t => t.ProductCategorySize)
                .WithMany()
                .HasForeignKey(t => t.ProductCategorySizeId)
                ;
        }
    }
}
