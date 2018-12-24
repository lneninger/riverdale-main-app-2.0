using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.File.InsertCommand.Models;
using Framework.Core.Messages;
using Framework.Storage.FileStorage.Models;
using System.IO;
using System.Transactions;
using Framework.Autofac;
using Framework.Storage.FileStorage.interfaces;
using ApplicationLogic.Business.Commands.File.UpdateCommand.Models;
using ApplicationLogic.Business.Commands.File.GetByIdCommand.Models;
using Framework.FileStorage.Standard.FileStorage.Models;
using Framework.Core.ReflectionHelpers;
using Framework.Commons;

namespace ApplicationLogic.Business.Commands.File.InsertCommand
{
    public class FileInsertCommand : AbstractDBCommand<DomainModel.File.File, IFileDBRepository>, IFileInsertCommand
    {
        public static string FirstStepDefaultRootFolder { get; } = "XX.XX";
        public static string FirstStepDefaultAccessPath { get; } = null;
        public static string FirstStepDefaultFileName { get; } = "XX.XX";
        public static string FirstStepDefaultFolderPath { get; } = "XX.XX";
        //public FileStorageSettings FileStorageSettings { get; }

        public FileInsertCommand(IDbContextScopeFactory dbContextScopeFactory, IFileDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<FileInsertCommandOutputDTO> Execute<T>(T input) where T : FileArgs
        {


            //using (var transaction = new TransactionScope())
            //{
            DomainModel.File.File file = null;
            var defaultFileStorageId = (string)typeof(FileSourceEnum).GetStaticPropertyValue(AppConfig.Instance.FileStorageSettings.DefaultFileStorageDestination);
            var fileStorageTypeId = input.FileSource ?? defaultFileStorageId;
            var result = new OperationResponse<FileInsertCommandOutputDTO>();

            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                file = new DomainModel.File.File
                {
                    RootPath = FileInsertCommand.FirstStepDefaultFileName,
                    AccessPath = FileInsertCommand.FirstStepDefaultAccessPath,
                    RelativePath = FileInsertCommand.FirstStepDefaultFolderPath,
                    FileName = FileInsertCommand.FirstStepDefaultFileName,
                    FileSize = input.UploadedFile.ContentLength,
                    ThumbnailFileSize = input.UploadedFile.ThumbnailContent.Length
                };

                OperationResponse<DomainModel.File.File> fileInsertResult = null;


                // First step. Save file without paths. 
                fileInsertResult = this.Repository.Insert(file);

                // Second step. Store file and grab its path details.
                input.FilePrefix = file.Id.ToString();
                FileStorageResultDTO fileStorageResult;
                using (var scope = IoCGlobal.NewScope("FileStorageScope"))
                {
                    var fileStorage = IoCGlobal.Resolve<IFileStorageService>(fileStorageTypeId, scope);
                    fileStorageResult = fileStorage.Save(input);
                }

                file.RootPath = fileStorageResult.RootPath;
                file.AccessPath = fileStorageResult.AccessPath;
                file.RelativePath = fileStorageResult.FolderPath;
                file.FileName = fileStorageResult.FileName;
                file.FullFilePath = fileStorageResult.FullFilePath;
                file.ThumbnailFileName = fileStorageResult.ThumbnailFileName;
                file.ThumbnailFullFilePath = fileStorageResult.ThumbnailFullFilePath;
                file.FileSystemTypeId = fileStorageResult.FileSourceId;
                dbContextScope.SaveChanges();

                var getById = this.Repository.GetById(file.Id);
                result.Bag = new FileInsertCommandOutputDTO
                {
                    Id = getById.Bag.Id
                };

                return result;
            }
        }

    }
}

