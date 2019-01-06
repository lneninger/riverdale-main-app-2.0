using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDatabaseMapping.Mappings.SaleOpportunity
{
    public class SaleOpportunitySettingsMap : BaseAbstractMap, IEntityTypeConfiguration<DomainModel.SaleOpportunity.SaleOpportunitySettings>
    {
        public SaleOpportunitySettingsMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<DomainModel.SaleOpportunity.SaleOpportunitySettings> builder)
        {
            builder.ToTable("SaleOpportunitySettings", SCHEMAS.SALE_OPPORTUNITY);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Delivered)
                .HasDefaultValue(false);

        }
    }
}
