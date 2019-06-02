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

        }
    }
}
