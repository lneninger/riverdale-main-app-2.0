using DomainModel;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings
{
    public class CountryMap : BaseAbstractMap, IEntityTypeConfiguration<Country>
    {

        public CountryMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country", SCHEMAS.CONFIG);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id);


            builder.Property(t => t.Alpha2Code)
                .HasMaxLength(2)
               .IsRequired(true);

            builder.Property(t => t.Alpha2Code)
                .HasMaxLength(3)
               .IsRequired(true);

            builder.Property(t => t.Name)
               .HasColumnType("nvarchar(100)")
               .IsRequired(true);


            // Seed
            builder.HasData(new Country { Id = 170, Alpha2Code = "CO", Alpha3Code = "COL", Name = "Colombia" });
            builder.HasData(new Country { Id = 218, Alpha2Code = "EC", Alpha3Code = "ECU", Name = "Ecuador" });
            builder.HasData(new Country { Id = 188, Alpha2Code = "CR", Alpha3Code = "CRI", Name = "Costa Rica" });
            builder.HasData(new Country { Id = 840, Alpha2Code = "US", Alpha3Code = "USA", Name = "United States of America" });


        }
    }
}
