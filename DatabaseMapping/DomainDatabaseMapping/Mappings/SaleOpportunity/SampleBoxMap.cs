using DomainModel.SaleOpportunity;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDatabaseMapping.Mappings.SaleOpportunity
{
    public class SampleBoxMap : BaseAbstractMap, IEntityTypeConfiguration<SampleBox>
    {
        public SampleBoxMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<SampleBox> builder)
        {
            builder.ToTable("SampleBox", SCHEMAS.SALE_OPPORTUNITY);

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Name)
                .HasMaxLength(200);

            builder.Property(t => t.SaleOpportunityId)
                .IsRequired();

            // Collections
        }
    }
}
