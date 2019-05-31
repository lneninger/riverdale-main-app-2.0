using DomainModel.Product;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings.File
{
    public class CompositionProductMap : BaseAbstractMap, IEntityTypeConfiguration<CompositionProduct>
    {

        public CompositionProductMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<CompositionProduct> builder)
        {
            builder.Property(t => t.ProductColorTypeId).IsRequired(false);

            builder.HasMany(t => t.Items)
                .WithOne(t => t.CompositionProduct)
                .HasForeignKey(t => t.CompositionProductId)
                ;


            builder.HasOne(t => t.ProductColorType)
                .WithMany()
                .HasForeignKey(t => t.ProductColorTypeId)
                ;
        }
    }
}
