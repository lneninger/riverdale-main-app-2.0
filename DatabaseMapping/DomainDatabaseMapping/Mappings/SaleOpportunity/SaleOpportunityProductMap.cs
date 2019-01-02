using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDatabaseMapping.Mappings.SaleOpportunity
{
    public class SaleOpportunityProductMap : BaseAbstractMap, IEntityTypeConfiguration<DomainModel.SaleOpportunity.SaleOpportunityProduct>
    {
        public SaleOpportunityProductMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<DomainModel.SaleOpportunity.SaleOpportunityProduct> builder)
        {
            builder.ToTable("SaleOpportunityProduct", SCHEMAS.SALE_OPPORTUNITY);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(t => t.SaleOpportunity)
               .WithMany(t => t.SaleOpportunityProducts)
               .HasForeignKey(t => t.SaleOpportunityId);


            builder.HasOne(t => t.Product)
               .WithMany()
               .HasForeignKey(t => t.ProductId);
        }
    }
}
