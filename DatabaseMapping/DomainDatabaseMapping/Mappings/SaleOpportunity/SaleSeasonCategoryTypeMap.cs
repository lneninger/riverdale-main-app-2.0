using DomainModel.SaleOpportunity;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDatabaseMapping.Mappings.SaleOpportunity
{
    public class SaleSeasonCategoryTypeMap : BaseAbstractMap, IEntityTypeConfiguration<SaleSeasonCategoryType>
    {
        public SaleSeasonCategoryTypeMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<SaleSeasonCategoryType> builder)
        {
            builder.ToTable("SaleSeasonCategoryType", SCHEMAS.SALE_OPPORTUNITY);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasMaxLength(10);

            builder.Property(t => t.Name)
               .HasMaxLength(25)
               .IsRequired(true);

            builder.Property(t => t.Description)
               .HasMaxLength(100)
               .IsRequired(true);

            // Seed
            builder.HasData(new SaleSeasonCategoryType { Id = "EVERYDAY", Name = "Every day", Description = "Available at any moment", CreatedAt = DateTime.UtcNow, CreatedBy = "Seed" });
            builder.HasData(new SaleSeasonCategoryType { Id = "HOLIDAY", Name = "Holiday", Description = "Holiday", CreatedAt = DateTime.UtcNow, CreatedBy = "Seed" });
            builder.HasData(new SaleSeasonCategoryType { Id = "YEARROUND", Name = "Year round", Description = "Sale around the year", CreatedAt = DateTime.UtcNow, CreatedBy = "Seed" });
        }
    }
}
