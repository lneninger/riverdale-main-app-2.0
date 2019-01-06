using DomainModel;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings
{
    public class LocationMap : BaseAbstractMap, IEntityTypeConfiguration<Location>
    {

        public LocationMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Location", SCHEMAS.CONFIG);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();


            builder.Property(t => t.City)
               .HasColumnType("nvarchar(100)")
               .IsRequired(true);

            builder.HasOne(t => t.Country)
                .WithMany()
                .HasForeignKey(t => t.CountryId)
                ;

            //Seed

        }
    }
}
