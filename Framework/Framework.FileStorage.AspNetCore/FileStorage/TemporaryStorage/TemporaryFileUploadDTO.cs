using Framework.Commons;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Framework.Storage.FileStorage.TemporaryStorage
{
    public class TemporaryFileUploadDTO
    {
        public IFormFile File { get; set; }
        public string Name { get; }
        public long Size { get; }
        public string ContentType { get; }
        public byte[] Content { get; }
        public Guid UniqueIdentifier { get; }
        public string TemporaryFileName
        {
            get
            {
                var result = $"{this.UniqueIdentifier}_{Path.GetFileName(this.Name)}";
                return result;
            }
        }

        public bool Saved { get; private set; }

        public TemporaryFileUploadDTO(IFormFile file)
        {
            this.UniqueIdentifier = Guid.NewGuid();
            this.File = file;
            this.Name = file.FileName;
            this.Size = file.Length;
            this.ContentType = file.ContentType;
            var memStream = new MemoryStream();
            file.OpenReadStream().CopyTo(memStream);
            this.Content = memStream.GetBuffer();
        }

        public TemporaryFileUpdatedResult SaveFile(string folderPath)
        {
            if (this.Saved) return null;

            if (string.IsNullOrWhiteSpace(folderPath))
            {
                folderPath = AppConfig.Instance.TemporaryFileFolder; 
            }

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var fileName = this.TemporaryFileName;
            var filePath = Path.Combine(folderPath, fileName);
            using (var fileStream = System.IO.File.Create(filePath)) {
                using (var memoryStream = new MemoryStream(this.Content)) {
                    memoryStream.CopyTo(fileStream);
                    memoryStream.Flush();
                }
            }
            this.Saved = true;

            return this.BuildResult();
        }

        private TemporaryFileUpdatedResult BuildResult()
        {
            var result = new TemporaryFileUpdatedResult();
            result.UniqueIdentifier = this.UniqueIdentifier;
            result.OriginalFileName = this.File.FileName;
            result.ContentLength = this.File.Length;
            result.TemporaryFileName = this.TemporaryFileName;
            result.ContentType = this.ContentType;

            return result;
        }
    }
}
