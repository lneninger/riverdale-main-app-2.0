using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Framework.Storage.FileStorage.TemporaryStorage
{
    public class UploadedFile: TemporaryFileUpdatedResult
    {
        protected string fileName;

        public override string TemporaryFileName {
            get
            {
                return fileName;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    return;
                }

                this.fileName = value;

                Inflate();
            }
        }

        public Stream FileStream { get; protected set; }
        public SplittedUploadedFileName NameElements { get; protected set; }

        protected void Inflate() {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                var exception = new ArgumentException($"Uploaded file name can no be null");
                throw exception;
            }

            this.NameElements = new SplittedUploadedFileName(fileName);
            if (this.NameElements.NoMatch) return;

            

            string baseTemporaryPath = TemporaryStorage.BaseTemporaryStorage;
            string filePath = Path.Combine(baseTemporaryPath, fileName);

            if (!File.Exists(filePath))
            {
                var exception = new ArgumentException($"Uploaded file not exists {this.TemporaryFileName}");
                exception.Data["Data"] = this;
                throw exception;
            }

            var bytes = File.ReadAllBytes(filePath);
            this.FileStream = new MemoryStream(bytes);
        }

        public class SplittedUploadedFileName
        {

            public SplittedUploadedFileName(string fileName)
            {
                var splitMatch = Regex.Match(fileName, "^(?<unique>[{(]?[0-9A-F]{8}[-]?([0-9A-F]{4}[-]?){3}[0-9A-F]{12}[)}]?)_(?<original>.*)$", RegexOptions.IgnoreCase);
                if (splitMatch.Length == 0)
                {
                    this.NoMatch = true;
                    return;
                }

                var unique = splitMatch.Groups["unique"];
                var original = splitMatch.Groups["original"];

                this.UniqueIdentifier = unique.Value;
                this.OriginalFileName = original.Value;
            }

            public string UniqueIdentifier { get; }
            public string OriginalFileName { get; }
            public bool NoMatch { get; }
        }
    }
}
