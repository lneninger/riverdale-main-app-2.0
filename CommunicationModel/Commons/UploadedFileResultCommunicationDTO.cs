using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationModel.Commons
{
    /// <summary>
    /// File persistence mechanism
    /// </summary>
    public class UploadedFileResult1
    {
        public string RootPath { get; set; }

        public string AccessPath { get; set; }

        public string FolderPath { get; set; }

        public string FileName { get; set; }

        public string FileSourceId { get; set; }
    }
}
