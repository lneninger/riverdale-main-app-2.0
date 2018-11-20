using DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings
{
    public class CustomerOpportunityMap : IEntityTypeConfiguration<CustomerOpportunity>
    {
        public void Configure(EntityTypeBuilder<CustomerOpportunity> builder)
        {
            builder.ToTable("CustomerOpportunity", SCHEMAS.QUOTE);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();


            builder.Property(t => t.CustomerId)
               .IsRequired(true);

            builder.HasOne(t => t.Customer)
                .WithMany(t => t.CustomerOpportunities)
                .HasForeignKey(t => t.CustomerId);
        }
    }
}
