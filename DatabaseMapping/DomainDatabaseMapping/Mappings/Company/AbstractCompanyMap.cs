using DomainModel.Company;
using DomainModel.Company.Customer;
using DomainModel.Company.Grower;
using DomainModel.Product;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings.Company
{
    public class AbstractCompanyMap : BaseAbstractMap, IEntityTypeConfiguration<AbstractCompany>
    {

        public AbstractCompanyMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<AbstractCompany> builder)
        {
            builder.ToTable("Company", SCHEMAS.CRM);
            builder.HasKey(t => t.Id);

            builder
            .HasDiscriminator<string>("CompanyTypeId")
            .HasValue<Grower>("GWR")
            .HasValue<Customer>("CUS")
            ;

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd()
                ;

            builder.Ignore(t => t.CompanyTypeEnum);

            builder.HasOne(t => t.CompanyType)
                .WithMany(t => t.Companies)
                .HasForeignKey(t => t.CompanyTypeId)
                ;

            builder.HasOne(t => t.Origin)
                .WithMany()
                .HasForeignKey(t => t.OriginId)
                .IsRequired(false);

        }
    }
}
