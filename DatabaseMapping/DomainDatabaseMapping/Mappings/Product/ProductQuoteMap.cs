using DomainModel.Product;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings.Product
{
    public class ProductQuoteMap : BaseAbstractMap, IEntityTypeConfiguration<ProductQuote>
    {

        public ProductQuoteMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<ProductQuote> builder)
        {
            builder.ToTable("ProductQuote", SCHEMAS.PRODUCT);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd()
                .HasMaxLength(4);

            builder.HasOne(c => c.Product)
                .WithMany(p => p.ProductQuotes)
                .HasForeignKey(c => c.ProductId)
                ;

            
        }
    }
}
