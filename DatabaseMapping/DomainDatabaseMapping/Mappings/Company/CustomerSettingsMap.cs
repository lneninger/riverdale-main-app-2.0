using DomainModel.Company.Customer;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings.Company
{
    public class CustomerSettingsMap : BaseAbstractMap, IEntityTypeConfiguration<CustomerSettings>
    {

        public CustomerSettingsMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<CustomerSettings> builder)
        {
            builder.ToTable("CustomerSettings", SCHEMAS.CRM);

            builder
                .HasKey(t => t.CustomerId);

            builder
                .Property(t => t.CustomerId)
                .ValueGeneratedNever();

            builder
                .Property(t => t.DefaultIsWet)
                .HasDefaultValue(false);

            builder
                .Property(t => t.DefaultOther)
                .IsRequired(false);


            builder
                .Property(t => t.DefaultRebate)
                .IsRequired(false);

            builder
                .Property(t => t.DefaultIsDeliver)
                .HasDefaultValue(false);

        }
    }
}
