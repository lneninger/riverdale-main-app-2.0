using DomainModel;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings
{
    public class SeasonMap : BaseAbstractMap, IEntityTypeConfiguration<Season>
    {

        public SeasonMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<Season> builder)
        {
            builder.ToTable("Season", SCHEMAS.MASTERS);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id);


            builder.Property(t => t.Name)
               .IsRequired(true);

            builder.Property(t => t.BeginDate)
               .IsRequired(false);

            builder.Property(t => t.EndDate)
               .IsRequired(false);

            builder.Property(t => t.Active)
               .HasDefaultValue(true);

        }
    }
}
