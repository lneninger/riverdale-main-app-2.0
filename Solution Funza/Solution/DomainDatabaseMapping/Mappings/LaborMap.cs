using DomainModel;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings
{
    public class LaborMap : BaseAbstractMap, IEntityTypeConfiguration<Labor>
    {

        public LaborMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<Labor> builder)
        {
            builder.ToTable("Labor", SCHEMAS.MASTERS);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id);


            builder.Property(t => t.Code)
               .IsRequired(true);

            builder.Property(t => t.Cost)
               .IsRequired(false);

            builder.Property(t => t.BouquetTypeId)
               .IsRequired(false);

            builder.Property(t => t.Active)
               .HasDefaultValue(true);

        }
    }
}
