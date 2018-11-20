using DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", SCHEMAS.CRM);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();


            builder.Property(t => t.Name)
               .HasColumnType("nvarchar(100)")
               .IsRequired(true);

            builder.Property(t => t.ERPId)
               .HasMaxLength(50)
               .IsRequired(true);
        }
    }
}
