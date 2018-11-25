using DomainModel;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings
{
    public class ProductColorMap : BaseAbstractMap, IEntityTypeConfiguration<ProductColorType>
    {

        public ProductColorMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<ProductColorType> builder)
        {
            builder.ToTable("ProductColorType", SCHEMAS.CONFIG);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasMaxLength(3)
                ;


            builder.Property(t => t.Name)
                .HasMaxLength(100)
               .IsRequired(true)
               ;

            builder.Property(t => t.HexCode)
                .HasMaxLength(6)
              .IsRequired(true)
              ;

            builder.Property(t => t.IsBasicColor)
             .IsRequired(true)
             .HasDefaultValue(false)
             ;

        }
    }
}
