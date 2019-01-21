﻿using DomainModel.Funza;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDatabaseMapping.Mappings.Funza
{
    public class ColorReferenceMap : BaseAbstractMap, IEntityTypeConfiguration<ColorReference>
    {

        public ColorReferenceMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<ColorReference> builder)
        {

            builder.ToTable("ColorReference", SCHEMAS.FUNZA);
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

            builder.Property(t => t.NameEnglish)
                .HasColumnType("varchar(200)")
                .IsRequired(true)
                ;

           
        }
    }
}
