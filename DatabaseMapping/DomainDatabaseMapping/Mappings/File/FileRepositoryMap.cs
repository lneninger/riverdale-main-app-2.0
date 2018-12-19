using DomainModel.File;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings.File
{
    public class FileRepositoryMap : BaseAbstractMap, IEntityTypeConfiguration<DomainModel.File.File>
    {

        public FileRepositoryMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<DomainModel.File.File> builder)
        {
            builder.ToTable("FileRepository", SCHEMAS.FILE);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();


            builder.Property(t => t.RootPath)
               .HasColumnType("nvarchar(300)")
               .IsRequired(false);

            builder.Property(t => t.AccessPath)
                .HasColumnType("nvarchar(500)")
                .IsRequired(false);

            builder.Property(t => t.RelativePath)
               .HasColumnType("nvarchar(500)")
               .IsRequired(false);

            builder.Property(t => t.FileName)
                .HasColumnType("nvarchar(150)")
                .IsRequired(true);

            builder.Property(t => t.ThumbnailFileName)
                .HasColumnType("nvarchar(150)")
                .IsRequired(false);



        }
    }
}
