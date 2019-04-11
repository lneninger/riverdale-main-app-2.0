using DomainModel.Product;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings.File
{
    public class CompositionProductBridgeProductMap : BaseAbstractMap, IEntityTypeConfiguration<CompositionProductBridge>
    {

        public CompositionProductBridgeProductMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<CompositionProductBridge> builder)
        {
            builder.ToTable("CompositionProductBridgeProduct", SCHEMAS.PRODUCT);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.FlowerProductCategoryGradeId)
                .IsRequired(false)
                ;


            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd()
                ;

            builder.HasOne(t => t.CompositionProduct)
                .WithMany(t => t.Items)
                .HasForeignKey(t => t.CompositionProductId)
                .OnDelete(DeleteBehavior.Restrict)
                ;

            builder.HasOne(t => t.CompositionItem)
                .WithMany()
                .HasForeignKey(t => t.CompositionItemId)
                .OnDelete(DeleteBehavior.Restrict)
                ;


            builder.HasOne(t => t.FlowerProductCategoryGrade)
                .WithMany()
                .HasForeignKey(t => t.FlowerProductCategoryGradeId)
                ;
        }
    }
}
