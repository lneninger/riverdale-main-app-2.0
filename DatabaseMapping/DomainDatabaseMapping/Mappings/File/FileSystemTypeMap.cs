using DomainModel.File;
using DomainModel.Identity;
using Framework.EF.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainDatabaseMapping.Mappings.Type
{
    public class FileSystemTypeMap : BaseAbstractMap, IEntityTypeConfiguration<FileSystemType>
    {

        public FileSystemTypeMap(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public void Configure(EntityTypeBuilder<FileSystemType> builder)
        {

            builder.ToTable("FileSystemType", SCHEMAS.FILE);
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasMaxLength(4);

            builder.Property(t => t.Name)
               .HasMaxLength(25)
               .IsRequired(true);

            builder.Property(t => t.Description)
               .HasMaxLength(100)
               .IsRequired(true);

            // Seed
            builder.HasData(new FileSystemType { Id = "SYS", Name = "File System", Description = "File System Repository", CreatedAt = DateTime.UtcNow, CreatedBy = "Seed" });
            builder.HasData(new FileSystemType { Id = "DB", Name = "Database", Description = "Internal Database Repository", CreatedAt = DateTime.UtcNow, CreatedBy = "Seed" });
            builder.HasData(new FileSystemType { Id = "AWS", Name = "AWS S3", Description = "Amazon S3 File Repository", CreatedAt = DateTime.UtcNow, CreatedBy = "Seed" });
            builder.HasData(new FileSystemType { Id = "AZU", Name = "Azure Storage", Description = "Azure Storage File Repository", CreatedAt = DateTime.UtcNow, CreatedBy = "Seed" });

        }
    }
}
