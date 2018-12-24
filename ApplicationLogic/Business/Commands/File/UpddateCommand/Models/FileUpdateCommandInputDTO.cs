using System;

namespace ApplicationLogic.Business.Commands.File.UpdateCommand.Models
{
    public class FileUpdateCommandInputDTO
    {
        public int Id { get; set; }
        public string RootPath { get; set; }
        public string AccessPath { get; set; }
        public string RelativePath { get; set; }
        public string FileName { get; set; }
        public int? FileSize { get; set; }
        public string FullFilePath { get; set; }

        public string ThumbnailFileName { get; set; }
        public int ThumbnaiFileSize { get; set; }
        public string ThumbnailFullFilePath { get; set; }

        public string FileType { get; set; }
        public string MimeContentType { get; set; }
        public string BelzonaDocumentTypeID { get; set; }
        public string ISOLanguageTypeID { get; set; }
        public string StorageTypeID { get; set; }
    }
}