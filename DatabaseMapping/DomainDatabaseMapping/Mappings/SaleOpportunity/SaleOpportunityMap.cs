using DomainModel.SaleOpportunity;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            // Relationships

             builder.HasMany(t => t.SaleOpportunityPriceLevels)
            .WithOne(t => t.SaleOpportunity)
            .HasForeignKey(t => t.SaleOpportunityId);

            builder.HasOne(t => t.Customer)
               .WithMany(t => t.SaleOpportunities)
               .HasForeignKey(t => t.CustomerId);

            // builder.HasOne(t => t.SaleOpportunitySettings)
            //.WithOne(t => t.SaleOpportunity)
            //.HasForeignKey<SaleOpportunitySettings>(t => t.SaleOpportunityId);

            //builder.HasOne(t => t.SaleSeasonType)
            //   .WithMany(p => p.SaleOpportunities)
            //   .HasForeignKey(t => t.SaleSeasonTypeId);


            //builder.HasMany(t => t.SampleBoxes)
            //   .WithOne(c => c.SaleOpportunity)
            //   .HasForeignKey(c => c.SaleOpportunityId);
        }
    }
}
