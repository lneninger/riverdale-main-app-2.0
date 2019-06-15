using DomainModel;
using DomainModel.Funza;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDatabaseMapping.Mappings
{
    public class CategoryMap : BaseAbstractMap, IEntityTypeConfiguration<Category>
    {

        public CategoryMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.ToTable("Category", SCHEMAS.FUNZA);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();

            builder.Property(t => t.FunzaId)
              .IsRequired();

            builder.Property(t => t.Name)
                .HasColumnType("varchar(200)")
                .IsRequired(true)
                ;

        }
    }
}
