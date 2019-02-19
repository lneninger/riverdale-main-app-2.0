using DomainModel.SaleOpportunity;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainDatabaseMapping.Mappings.SaleOpportunity
{
    public class SaleOpportunityPriceLevelMap : BaseAbstractMap, IEntityTypeConfiguration<DomainModel.SaleOpportunity.SaleOpportunityPriceLevel>
    {
        public SaleOpportunityPriceLevelMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<DomainModel.SaleOpportunity.SaleOpportunityPriceLevel> builder)
        {
            builder.ToTable("SaleOpportunityPriceLevel", SCHEMAS.SALE_OPPORTUNITY);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();


            // Relationships

            builder.HasOne(t => t.SaleSeasonType)
               .WithMany(p => p.SaleOpportunityPriceLevels)
               .HasForeignKey(t => t.SaleSeasonTypeId);


            builder.HasMany(t => t.SampleBoxes)
               .WithOne(c => c.SaleOpportunityPriceLevel)
               .HasForeignKey(c => c.SaleOpportunityPriceLevelId);
        }
    }
}
