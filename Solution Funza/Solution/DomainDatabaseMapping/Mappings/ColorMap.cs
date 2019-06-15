using DomainModel;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainDatabaseMapping.Mappings
{
    public class ColorMap : BaseAbstractMap, IEntityTypeConfiguration<Color>
    {

        public ColorMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<Color> builder)
        {

            builder.ToTable("Color", SCHEMAS.MASTERS);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(t => t.FunzaId)
              .IsRequired();

            builder.Property(t => t.Name)
                .HasColumnType("varchar(200)")
                .IsRequired(true)
                ;

            builder.Property(t => t.NameEnglish)
                .HasColumnType("varchar(200)")
                .IsRequired(true)
                ;

           
        }
    }
}
