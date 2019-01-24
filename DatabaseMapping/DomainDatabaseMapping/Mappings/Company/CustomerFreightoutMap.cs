using DomainModel.Company.Customer;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings.Company
{
    public class CustomerFreightoutMap : BaseAbstractMap, IEntityTypeConfiguration<CustomerFreightout>
    {

        public CustomerFreightoutMap(ModelBuilder modelBuilder): base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<CustomerFreightout> builder)
        {
            builder.ToTable("CustomerFreightout", SCHEMAS.QUOTE);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd()
                ;

            builder.Property(t => t.CustomerId)
               .IsRequired(true);

            builder.Property(t => t.CustomerFreightoutRateTypeId)
               .IsRequired(true);

            builder.Property(t => t.Cost)
               .IsRequired(true);

            builder.Property(t => t.WProtect)
               .IsRequired(true);

            builder.Property(t => t.DateFrom)
               .IsRequired(true);

            builder.Property(t => t.DateTo)
               .IsRequired(true);

            // Relations
            builder.HasOne(t => t.Customer)
                .WithMany(t => t.CustomerFreightouts)
                .HasForeignKey(t => t.CustomerId);

            builder.HasOne(t => t.CustomerFreightoutRateType)
                .WithMany(t => t.CustomerFreightouts)
                .HasForeignKey(t => t.CustomerFreightoutRateTypeId);
        }
    }
}
