using DomainModel.Funza;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDatabaseMapping.Mappings.Funza
{
    public class QuoteReferenceMap : BaseAbstractMap, IEntityTypeConfiguration<QuoteReference>
    {

        public QuoteReferenceMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<QuoteReference> builder)
        {

            builder.ToTable("QuoteReference", SCHEMAS.FUNZA);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(t => t.FunzaId)
              .IsRequired();

            builder.Property(t => t.Title)
                .HasColumnType("varchar(100)")
                .IsRequired(true)
                ;

           
        }
    }
}
