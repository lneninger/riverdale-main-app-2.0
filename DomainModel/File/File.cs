using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.File
{
    public class File: AbstractBaseEntity, ILogicalDeleteEntity
    {
        public int Id { get; set; }

        public string FileSystemTypeId { get; set; }

        public virtual FileSystemType FileSystemType { get; set; }

        public string RootPath { get; set; }

        public string AccessPath { get; set; }

        public string RelativePath { get; set; }

        public string FileName { get; set; }

        public string FullFilePath { get; set; }

        public int FileSize { get; set; }


        public string ThumbnailFileName { get; set; }

        public string ThumbnailFullFilePath { get; set; }

        public int ThumbnailFileSize { get; set; }

        public DateTime? DeletedAt { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
