using DomainModel.File;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings.File
{
    public class FileRepositoryMap : BaseAbstractMap, IEntityTypeConfiguration<FileRepository>
    {

        public FileRepositoryMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<FileRepository> builder)
        {
            builder.ToTable("FileRepository", SCHEMAS.FILE);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();


            builder.Property(t => t.RootPath)
               .HasColumnType("nvarchar")
               .HasMaxLength(100)
               .IsRequired(true);

            builder.Property(t => t.AccessPath)
                .HasColumnType("nvarchar")
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(t => t.RelativePath)
               .HasColumnType("nvarchar")
               .HasMaxLength(500)
               .IsRequired(false);

            builder.Property(t => t.FileName)
                .HasColumnType("nvarchar")
                .HasMaxLength(150)
                .IsRequired(true);

            builder.Property(t => t.ThumbnailFileName)
                .HasColumnType("nvarchar")
                .HasMaxLength(150)
                .IsRequired(false);



        }
    }
}
