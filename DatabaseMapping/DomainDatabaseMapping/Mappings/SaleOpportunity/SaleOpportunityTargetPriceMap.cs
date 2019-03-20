using DomainModel.SaleOpportunity;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainDatabaseMapping.Mappings.SaleOpportunity
{
    public class SaleOpportunityTargetPriceMap : BaseAbstractMap, IEntityTypeConfiguration<DomainModel.SaleOpportunity.SaleOpportunityTargetPrice>
    {
        public SaleOpportunityTargetPriceMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<DomainModel.SaleOpportunity.SaleOpportunityTargetPrice> builder)
        {
            builder.ToTable("SaleOpportunityTargetPrice", SCHEMAS.SALE_OPPORTUNITY);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();


            // Relationships

            builder.HasOne(t => t.SaleSeasonType)
               .WithMany(p => p.SaleOpportunityTargetPrices)
               .HasForeignKey(t => t.SaleSeasonTypeId);


            builder.HasMany(t => t.SampleBoxes)
               .WithOne(c => c.SaleOpportunityTargetPrice)
               .HasForeignKey(c => c.SaleOpportunityTargetPriceId);
        }
    }
}
