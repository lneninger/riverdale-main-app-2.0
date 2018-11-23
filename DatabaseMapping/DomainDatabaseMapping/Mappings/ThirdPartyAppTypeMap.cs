using DomainModel;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings
{
    public class ThirdPartyAppTypeMap : BaseAbstractMap, IEntityTypeConfiguration<ThirdPartyAppType>
    {

        public ThirdPartyAppTypeMap(ModelBuilder modelBuilder): base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<ThirdPartyAppType> builder)
        {
            builder.ToTable("ThirdPartyAppType", SCHEMAS.CONFIG);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasMaxLength(6);

            builder.Property(t => t.Name)
               .HasColumnType("nvarchar(50)")
               .IsRequired(true);

            // Seed
            builder.HasData(new ThirdPartyAppType { Id = "BISERP", Name = "Business ERP", CreatedAt = DateTime.UtcNow, CreatedBy = "Seed" });
            builder.HasData(new ThirdPartyAppType { Id = "SFORCE", Name = "Salesforce", CreatedAt = DateTime.UtcNow, CreatedBy = "Seed" });
        }
    }
}
