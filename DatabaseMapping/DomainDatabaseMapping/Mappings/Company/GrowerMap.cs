using DomainModel.Company.Grower;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings.Company
{
    public class GrowerMap : BaseAbstractMap, IEntityTypeConfiguration<Grower>
    {

        public GrowerMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<Grower> builder)
        {
            builder.Property(t => t.Code)
               .HasMaxLength(3)
               .IsRequired(true);

            builder.HasOne(t => t.GrowerType)
                .WithMany(t => t.Growers)
                .HasForeignKey(t => t.GrowerTypeId);

            
            builder.HasMany(t => t.GrowerFreights)
                .WithOne(t => t.Grower)
                .HasForeignKey(t => t.GrowerId);
        }
    }
}
