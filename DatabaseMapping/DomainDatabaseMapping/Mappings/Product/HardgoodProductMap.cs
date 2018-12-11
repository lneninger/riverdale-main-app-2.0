using DomainModel.Product;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings.File
{
    public class HardgoodProductMap : BaseAbstractMap, IEntityTypeConfiguration<HardgoodProduct>
    {

        public HardgoodProductMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<HardgoodProduct> builder)
        {

        }
    }
}
