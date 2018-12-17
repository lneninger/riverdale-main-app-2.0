using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.FileStorage.Standard.FileStorage.Models
{
    public class FileStorageSettings
    {
        public string DefaultFileStorageDestination { get; set; }
        public string TemporaryFolderPath { get; set; }
        public FileStorageAWSSettings AWS { get; set; }
    }

    public class FileStorageAWSSettings
    {
        public string AWSFileRepoAccessKey { get; set; }
        public string AWSFileRepoSecretKey { get; set; }
        public string AWSFileStoreRootURL { get; set; }
        public string AWSFileRepoRegionEndPoint { get; set; }
        public string AWSFileRepoBucketName { get; set; }
    }

}
