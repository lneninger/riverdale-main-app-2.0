using DomainModel.Product;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDatabaseMapping.Mappings.Product
{
    public class FlowerProductCategoryMap : BaseAbstractMap, IEntityTypeConfiguration<FlowerProductCategory>
    {

        public FlowerProductCategoryMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<FlowerProductCategory> builder)
        {
            builder.ToTable("FlowerProductCategory", SCHEMAS.PRODUCT);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasMaxLength(20);

            builder.Property(t => t.Name)
                .HasMaxLength(30)
                ;

            builder.HasMany(t => t.Flowers)
                .WithOne(t => t.FlowerProductCategory)
                .HasForeignKey(c => c.FlowerProductCategoryId)
                ;

            builder.HasMany(t => t.Grades)
                .WithOne(t => t.FlowerProductCategory)
                .HasForeignKey(c => c.FlowerProductCategoryId)
                ;
        }
        }
}
