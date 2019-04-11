using DomainModel.Product;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings.Product
{
    public class FlowerProductCategoryGradeMap : BaseAbstractMap, IEntityTypeConfiguration<FlowerProductCategoryGrade>
    {

        public FlowerProductCategoryGradeMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<FlowerProductCategoryGrade> builder)
        {
            builder.ToTable("FlowerProductCategoryGrade", SCHEMAS.PRODUCT);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasMaxLength(4);

            builder.HasOne(t => t.FlowerProductCategory)
                .WithMany(t => t.Grades)
                .HasForeignKey(t => t.FlowerProductCategoryId)
                ;

            
        }
    }
}
