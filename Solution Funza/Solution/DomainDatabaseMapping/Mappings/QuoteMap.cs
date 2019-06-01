using DomainModel;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings
{
    public class QuoteMap : BaseAbstractMap, IEntityTypeConfiguration<Quote>
    {

        public QuoteMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<Quote> builder)
        {
            builder.ToTable("Quote", SCHEMAS.FUNZA);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id);


            builder.Property(t => t.ProductId)
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
            builder.HasData(new Country { Id = 528, Alpha2Code = "NL", Alpha3Code = "NLD", Name = "Netherlands" });
            builder.HasData(new Country { Id = 320, Alpha2Code = "GT", Alpha3Code = "GTM", Name = "Guatemala" });
            builder.HasData(new Country { Id = 214, Alpha2Code = "DO", Alpha3Code = "DOM", Name = "Dominican Republic" });
            builder.HasData(new Country { Id = 604, Alpha2Code = "PE", Alpha3Code = "PER", Name = "Peru" });
            builder.HasData(new Country { Id = 380, Alpha2Code = "IT", Alpha3Code = "ITA", Name = " Italy" });
            builder.HasData(new Country { Id = 32, Alpha2Code = "AR", Alpha3Code = "ARG", Name = " Argentina" });


        }
    }
}
