using DomainModel;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings
{
    public class CustomerFreightoutRateTypeMap : BaseAbstractMap, IEntityTypeConfiguration<CustomerFreightoutRateType>
    {

        public CustomerFreightoutRateTypeMap(ModelBuilder modelBuilder): base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<CustomerFreightoutRateType> builder)
        {
            builder.ToTable("CustomerFreightoutRateType", SCHEMAS.QUOTE);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasMaxLength(4);

            builder.Property(t => t.Name)
               .HasMaxLength(25)
               .IsRequired(true);

            builder.Property(t => t.Description)
               .HasMaxLength(100)
               .IsRequired(true);

            // Seed
            builder.HasData(new CustomerFreightoutRateType { Id = "CUBE", Name = "Cube", Description = "Rate by volume(cubic meters)", CreatedAt = DateTime.UtcNow, CreatedBy = "Seed" });
            builder.HasData(new CustomerFreightoutRateType { Id = "BOX", Name = "Box", Description="Rate by box(amount of containers)", CreatedAt = DateTime.UtcNow, CreatedBy = "Seed" });
        }
    }
}
