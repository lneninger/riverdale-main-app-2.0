﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.Models.FileStorage.Models;
using Framework.Storage.FileStorage.Models;

namespace Framework.Storage.FileStorage.StorageImplementations
{
    /// <summary>
    /// FileStorageService implementation for Windows File System
    /// </summary>
    /// <seealso cref="Framework.Storage.FileStorage.BaseFileStorageService" />
    public class FileSystemStorage : BaseFileStorageService
    {
        public static string Identifier { get; } = FileSourceEnum.FileSystem;
        public static string FileSystemBaseStoragePath { get; } = ConfigurationManager.AppSettings["FileSystemBaseStoragePath"];

        /// <summary>
        /// Retrieves the file from Windows FileSystem.
        /// </summary>
        /// <param name="rootFolder">The root folder.</param>
        /// <param name="accessPath">The access path.</param>
        /// <param name="folderPath">The folder path.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public override Task<byte[]> RetrieveFile(string rootFolder, string accessPath, string folderPath, string fileName)
        {
            var fullFilePath = Path.Combine(rootFolder, folderPath, fileName);
            var result = File.ReadAllBytes(fullFilePath);
            return Task.FromResult(result);
        }

        /// <summary>
        /// Internals the save.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        protected override FileResult InternalSave(FileArgs args)
        {
            var targetRelativePathElements = args.GetRelativePathElements();
            var targetFileNameElements = args.GetFileNameElements();

            var rootPath = args.TargetRootPath ?? FileSystemStorage.FileSystemBaseStoragePath;
            var folderPath = (args.BuildRelativePath ?? this.BuildRelativePath)(targetRelativePathElements);
            var fileName = (args.BuildFileName ?? this.BuildFileName)(targetFileNameElements);
            fileName += Path.GetExtension(args.UploadedFile.OriginalFileName);

            var directoryPath = Path.Combine(rootPath, folderPath);
            var relativeFilePath = Path.Combine(folderPath, fileName);
            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                var filePath = Path.Combine(directoryPath, fileName);
                
                using (var fileStream = File.OpenWrite(filePath))
                {
                    using (var streamWriter = new BinaryWriter(fileStream))
                    {
                        streamWriter.Write(args.FileContent);
                    }
                }

                var result = new FileResult
                {
                    RootPath = rootPath,
                    AccessPath = null,
                    FolderPath = folderPath,
                    FileName = fileName,
                    FileSourceId = Identifier
                };

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
