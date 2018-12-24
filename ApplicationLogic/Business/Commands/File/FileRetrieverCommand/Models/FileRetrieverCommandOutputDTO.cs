using Framework.FileStorage.AspNetCore.FileStorage.Models;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.File.FileRetrieverCommand.Models
{
    public class FileRetrieverCommandOutputDTO: IFileData
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public object Identifier {get; set; }

        public string FileSystemTypeId { get; set; }

        public string ThumbnailFileName {get; set; }

        public string FileName {get; set; }

        public string RootPath {get; set; }

        public string AccessPath {get; set; }

        public string RelativePath {get; set; }

        public string FullFilePath { get; set; }

        public string ThumbnailFullFilePath { get; set; }
    }
}