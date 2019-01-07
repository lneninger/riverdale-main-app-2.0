using DomainModel;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings
{
    public class GrowerMap : BaseAbstractMap, IEntityTypeConfiguration<Grower>
    {

        public GrowerMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<Grower> builder)
        {
            builder.ToTable("Grower", SCHEMAS.CRM);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Code)
               .HasMaxLength(3)
               .IsRequired(true);

            builder.Property(t => t.Name)
               .HasColumnType("nvarchar(100)")
               .IsRequired(true);

            builder.HasOne(t => t.GrowerType)
                .WithMany(t => t.Growers)
                .HasForeignKey(t => t.GrowerTypeId);

            builder.HasOne(t => t.Origin)
                .WithMany()
                .HasForeignKey(t => t.OriginId);

            builder.HasMany(t => t.GrowerFreights)
                .WithOne(t => t.Grower)
                .HasForeignKey(t => t.GrowerId);

        }
    }
}
