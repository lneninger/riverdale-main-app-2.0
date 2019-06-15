using DomainModel;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDatabaseMapping.Mappings.Funza
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

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(t => t.ProductId)
               .IsRequired(true);

            builder.Property(t => t.FunzaId)
              .IsRequired();

            builder.Property(t => t.Title)
                .HasColumnType("varchar(100)")
                .IsRequired(true)
                ;

           
        }
    }
}
