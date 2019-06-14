using DomainModel;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings
{
    public class GoodPriceMap: BaseAbstractMap, IEntityTypeConfiguration<GoodPrice>
    {

        public GoodPriceMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<GoodPrice> builder)
        {
            builder.ToTable("GoodPrice", SCHEMAS.FUNZA);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id);

            builder.Property(t => t.Active)
               .HasDefaultValue(true);

        }
    }
}
