using DomainModel;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainDatabaseMapping.Mappings
{
    public class PackingReferenceMap : BaseAbstractMap, IEntityTypeConfiguration<Packing>
    {

        public PackingReferenceMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<Packing> builder)
        {

            builder.ToTable("Packing", SCHEMAS.FUNZA);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(t => t.FunzaId)
              .IsRequired();

            builder.Property(t => t.Name)
                .HasColumnType("varchar(200)")
                .IsRequired(false)
                ;

            builder.Property(t => t.NameEnglish)
               .HasColumnType("varchar(200)")
               .IsRequired(false)
               ;

            builder.Property(t => t.Description)
               .HasColumnType("varchar(200)")
               .IsRequired(false)
               ;

            builder.Property(t => t.Image)
               .HasColumnType("varchar(200)")
               .IsRequired(false)
               ;
            
        }
    }
}
