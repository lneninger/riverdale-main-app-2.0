using DomainModel;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainDatabaseMapping.Mappings
{
    public class ProductReferenceMap : BaseAbstractMap, IEntityTypeConfiguration<Product>
    {

        public ProductReferenceMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.ToTable("Product", SCHEMAS.FUNZA);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(t => t.FunzaId)
              .IsRequired();

            builder.Property(t => t.CategoryName)
                .HasColumnType("varchar(200)")
                .IsRequired(false)
                ;

            builder.Property(t => t.Code)
               .HasColumnType("varchar(200)")
               .IsRequired(false)
               ;

            builder.Property(t => t.Description)
               .HasColumnType("varchar(200)")
               .IsRequired(false)
               ;

            builder.Property(t => t.Comments)
               .HasColumnType("varchar(200)")
               .IsRequired(false)
               ;

            builder.Property(t => t.ProductTypeName)
               .HasColumnType("varchar(200)")
               .IsRequired(false)
               ;

            builder.Property(t => t.ReferenceCode)
               .HasColumnType("varchar(200)")
               .IsRequired(false)
               ;

            builder.Property(t => t.ReferenceDescription)
               .HasColumnType("varchar(200)")
               .IsRequired(false)
               ;

            builder.Property(t => t.ReferenceTypeName)
               .HasColumnType("varchar(200)")
               .IsRequired(false)
               ;
            
        }
    }
}
