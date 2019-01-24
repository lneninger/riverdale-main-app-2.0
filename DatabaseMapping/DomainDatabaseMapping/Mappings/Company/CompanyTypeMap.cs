using DomainModel.Company;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings.Company
{
    public class CompanyTypeMap : BaseAbstractMap, IEntityTypeConfiguration<CompanyType>
    {

        public CompanyTypeMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<CompanyType> builder)
        {
            builder.ToTable("CompanyType", SCHEMAS.CRM);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasMaxLength(8);


            builder.Property(t => t.Name)
               .HasColumnType("nvarchar(100)")
               .IsRequired(true);

            builder.Property(t => t.Description)
              .HasColumnType("nvarchar(250)")
              .IsRequired(false);


            builder.HasData(new CompanyType { Id = "GWR", Name = "Grower", Description = "Grower/Supplier of Riverdale", CreatedAt = DateTime.UtcNow, CreatedBy = "Seed" });
            builder.HasData(new CompanyType { Id = "CUS", Name = "Customer", Description = "Customer of Riverdale", CreatedAt = DateTime.UtcNow, CreatedBy = "Seed" });
        }
    }
}
