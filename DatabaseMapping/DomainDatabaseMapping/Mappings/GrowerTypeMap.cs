using DomainModel;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings
{
    public class GrowerTypeMap : BaseAbstractMap, IEntityTypeConfiguration<GrowerType>
    {

        public GrowerTypeMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<GrowerType> builder)
        {
            builder.ToTable("GrowerType", SCHEMAS.CRM);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasMaxLength(8);


            builder.Property(t => t.Name)
               .HasColumnType("nvarchar(100)")
               .IsRequired(true);

            builder.Property(t => t.Description)
              .HasColumnType("nvarchar(250)")
              .IsRequired(false);


            builder.HasData(new GrowerType { Id = "THIRD", Name = "Third Party", Description = "Third Party Grower", CreatedAt = DateTime.UtcNow, CreatedBy = "Seed" });
            builder.HasData(new GrowerType { Id = "FUNZAMIA", Name = "Funza Miami", Description = "Branch Miami", CreatedAt = DateTime.UtcNow, CreatedBy = "Seed" });
            builder.HasData(new GrowerType { Id = "FUNZABTA", Name = "Funza Bogota", Description = "Branch Bogota", CreatedAt = DateTime.UtcNow, CreatedBy = "Seed" });
        }
    }
}
