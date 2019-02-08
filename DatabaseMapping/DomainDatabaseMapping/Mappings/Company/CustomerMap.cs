using DomainModel.Company.Customer;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings.Company
{
    public class CustomerMap : BaseAbstractMap, IEntityTypeConfiguration<Customer>
    {

        public CustomerMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
               .HasOne(t => t.CustomerSettings)
               .WithOne(c => c.Customer)
               .HasForeignKey<CustomerSettings>(t => t.CustomerId);
        }
    }
}
