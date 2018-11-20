using DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings
{
    public class AbstractBaseEntityMap : IEntityTypeConfiguration<AbstractBaseEntity>
    {
        public void Configure(EntityTypeBuilder<AbstractBaseEntity> builder)
        {
            builder.Property(t => t.CreatedAt)
                .IsRequired();

            builder.Property(t => t.CreatedBy)
                .HasColumnType("nvarchar")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(t => t.UpdatedAt)
                .IsRequired();

            builder.Property(t => t.UpdatedBy)
                .HasColumnType("nvarchar")
                .HasMaxLength(150)
                .IsRequired();



        }
    }
}
