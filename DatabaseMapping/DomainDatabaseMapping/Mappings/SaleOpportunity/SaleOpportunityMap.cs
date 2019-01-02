using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDatabaseMapping.Mappings.SaleOpportunity
{
    public class SaleOpportunityMap : BaseAbstractMap, IEntityTypeConfiguration<DomainModel.SaleOpportunity.SaleOpportunity>
    {
        public SaleOpportunityMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<DomainModel.SaleOpportunity.SaleOpportunity> builder)
        {
            builder.ToTable("SaleOpportunity", SCHEMAS.SALE_OPPORTUNITY);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Name)
               .HasMaxLength(100)
               .IsRequired(true);


            builder.HasOne(t => t.Customer)
               .WithMany(t => t.SaleOpportunities)
               .HasForeignKey(t => t.CustomerId);


            builder.HasOne(t => t.SaleSeasonType)
               .WithMany(t => t.SaleOpportunities)
               .HasForeignKey(t => t.SaleSeasonTypeId);
        }
    }
}
