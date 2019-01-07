using DomainModel;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings
{
    public class GrowerFreightMap : BaseAbstractMap, IEntityTypeConfiguration<GrowerFreight>
    {

        public GrowerFreightMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<GrowerFreight> builder)
        {
            builder.ToTable("GrowerFreight", SCHEMAS.CRM);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();


            builder.Property(t => t.BasicFreight)
                .HasDefaultValue(0)
               .IsRequired(true);


            builder.Property(t => t.HolidayFreight)
                .HasDefaultValue(0)
               .IsRequired(true);

            builder.Property(t => t.From)
               .IsRequired(true);

            builder.Property(t => t.To)
               .IsRequired(true);

        }
    }
}
