using DomainModel.SaleOpportunity;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDatabaseMapping.Mappings.SaleOpportunity
{
    public class SampleBoxProductMap : BaseAbstractMap, IEntityTypeConfiguration<SampleBoxProduct>
    {
        public SampleBoxProductMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<SampleBoxProduct> builder)
        {
            builder.ToTable("SampleBoxProduct", SCHEMAS.SALE_OPPORTUNITY);

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.SaleOpportunityTargetPriceProductId)
                .IsRequired(true);

            builder.HasOne(t => t.SaleOpportunityTargetPriceProduct)
               .WithMany()
               .HasForeignKey(t => t.SaleOpportunityTargetPriceProductId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.SampleBox)
                .WithMany(t => t.SampleBoxProducts)
                .HasForeignKey(t => t.SampleBoxId);
        }
    }
}
