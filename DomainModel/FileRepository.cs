using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class FileRepository: AbstractBaseEntity
    {
        public int Id { get; set; }

        public string RootPath { get; set; }
        public string AccessPath { get; set; }
        public string RelativePath { get; set; }
        public string FileName { get; set; }
        public string ThumbnailFileName { get; set; }
    }
}
