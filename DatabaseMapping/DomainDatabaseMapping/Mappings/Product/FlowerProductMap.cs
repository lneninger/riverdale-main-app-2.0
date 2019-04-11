using DomainModel.Product;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings.Product
{
    public class FlowerProductMap : BaseAbstractMap, IEntityTypeConfiguration<FlowerProduct>
    {

        public FlowerProductMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<FlowerProduct> builder)
        {
            builder.Property(t => t.FlowerProductCategoryId)
                .HasMaxLength(20)
                .IsRequired(false);

            builder.HasOne(c => c.FlowerProductCategory)
                .WithMany(p => p.Flowers)
                .HasForeignKey(c => c.FlowerProductCategoryId)
                ;
        }
    }
}
