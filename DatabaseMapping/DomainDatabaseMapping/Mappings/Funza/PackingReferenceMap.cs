using DomainModel.Funza;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDatabaseMapping.Mappings.Funza
{
    public class PackingReferenceMap : BaseAbstractMap, IEntityTypeConfiguration<PackingReference>
    {

        public PackingReferenceMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<PackingReference> builder)
        {

            builder.ToTable("PackingReference", SCHEMAS.FUNZA);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(t => t.FunzaId)
              .IsRequired();

            builder.Property(t => t.Name)
                .HasColumnType("varchar(200)")
                .IsRequired(false)
                ;

            builder.Property(t => t.NameEnglish)
               .HasColumnType("varchar(200)")
               .IsRequired(false)
               ;

            builder.Property(t => t.Description)
               .HasColumnType("varchar(200)")
               .IsRequired(false)
               ;

            builder.Property(t => t.Image)
               .HasColumnType("varchar(200)")
               .IsRequired(false)
               ;
            
        }
    }
}
