using DomainModel;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings
{
    public class CustomerThirdPartyAppSettingMap : BaseAbstractMap, IEntityTypeConfiguration<CustomerThirdPartyAppSetting>
    {

        public CustomerThirdPartyAppSettingMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<CustomerThirdPartyAppSetting> builder)
        {
            builder.ToTable("CustomerThirdPartyAppSetting", SCHEMAS.CRM);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder.Ignore(t => t.ThirdPartyAppTypeEnum);

            builder.Property(t => t.ThirdPartyCustomerId)
               .HasColumnType("nvarchar(100)")
               .IsRequired(false);

            builder.HasOne(t => t.Customer)
               .WithMany(t => t.CustomerThirdPartyAppSettings)
               .HasForeignKey(t => t.CustomerId)
               ;

            builder.HasOne(t => t.ThirdPartyAppType)
               .WithMany()
               .HasForeignKey(t => t.ThirdPartyAppTypeId)
               ;
        }
    }
}
