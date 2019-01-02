using DomainModel.SaleOpportunity;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDatabaseMapping.Mappings.SaleOpportunity
{
    public class SaleSeasonTypeMap : BaseAbstractMap, IEntityTypeConfiguration<SaleSeasonType>
    {
        public SaleSeasonTypeMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<SaleSeasonType> builder)
        {
            builder.ToTable("SaleSeasonType", SCHEMAS.SALE_OPPORTUNITY);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd()
                ;

            builder.Property(t => t.Name)
               .HasMaxLength(25)
               .IsRequired(true);

            builder.Property(t => t.Description)
               .HasMaxLength(100)
               .IsRequired(true);

            builder.HasOne(t => t.SaleSeasonCategoryType)
                .WithMany(t => t.SaleSeasons)
                .HasForeignKey(t => t.SaleSeasonCategoryTypeId)
               .IsRequired(true);


            // Seed
        }
    }
}
