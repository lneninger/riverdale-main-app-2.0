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

        public FileInsertCommand(/*FileStorageSettings fileStorageSettings, */IDbContextScopeFactory dbContextScopeFactory, IFileDBRepository repository) : base(dbContextScopeFactory, repository)
        {
            //this.FileStorageSettings = null;// fileStorageSettings;
        }

        public OperationResponse<FileInsertCommandOutputDTO> Execute<T>(T input) where T : FileArgs
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {

                var result = this.Save(input);

                return result;
            }
        }

        public OperationResponse<FileInsertCommandOutputDTO> Execute(FileInsertCommandInputDTO input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.Insert(input);
            }
        }


        public OperationResponse<FileInsertCommandOutputDTO> Save(FileArgs args)
        {
            var result = new OperationResponse<FileInsertCommandOutputDTO>();
            //var language = this.DbModel.ISOLanguageTypes.FirstOrDefault(o => o.ISOLanguageTypeID == args.LanguageTypeId);

            var defaultFileStorageId = (string)typeof(FileSourceEnum).GetStaticPropertyValue(AppConfig.Instance.FileStorageSettings.DefaultFileStorageDestination);
            var fileStorageTypeId = args.FileSource ?? defaultFileStorageId;
            var fileDto = new FileInsertCommandInputDTO
            {
                //Bel_OriginalFullFileName  = args.OriginalFileName,
                RootPath = FileInsertCommand.FirstStepDefaultFileName,
                AccessPath = FileInsertCommand.FirstStepDefaultAccessPath,
                RelativePath = FileInsertCommand.FirstStepDefaultFolderPath,
                FileName = FileInsertCommand.FirstStepDefaultFileName,
                FileContent = args.FileContent,
                FileThumbnailContent = args.FileThumbnailContent,
                //FileSize = args.FileContent.Length,
                FileType = Path.GetExtension(args.UploadedFile.OriginalFileName),
                MimeContentType = args.ContentType,
                BelzonaDocumentTypeID = args.FileTypeId,
                ISOLanguageTypeID = args.LanguageTypeId,
                StorageTypeID = fileStorageTypeId,
            };

            OperationResponse<FileInsertCommandOutputDTO> fileInsertResult = null;

            using (var transaction = new TransactionScope())
            {
                // First step. Save file without paths. 
                fileInsertResult = this.Repository.Insert(fileDto);

                // Second step. Store file and grab its path details.
                args.FilePrefix = fileInsertResult.Bag.Id.ToString();
                //var secondStepArgs = new DefaultFileArgs(entity.FileRepositoryID, args);

                // insert entity guid id at the begining of filename elements
                //var fileNameElements = new List<string>(secondStepArgs.TargetFileNameElements);
                //fileNameElements.Insert(0, entity.FileRepositoryID.ToString());
                //secondStepArgs.TargetFileNameElements = fileNameElements.ToArray();
                FileStorageResultDTO fileStorageResult;
                using (var scope = IoCGlobal.NewScope("FileStorageScope"))
                {
                    var fileStorage = IoCGlobal.Resolve<IFileStorageService>(fileStorageTypeId, scope);
                    //result = fileStorage.Save(secondStepArgs);
                    fileStorageResult = fileStorage.Save(args);
                }

                var fileUpdate = new FileUpdateCommandInputDTO
                {
                    Id = fileInsertResult.Bag.Id,
                    RootPath = fileStorageResult.RootPath,
                    AccessPath = fileStorageResult.AccessPath,
                    RelativePath = fileStorageResult.FolderPath,
                    FileName = fileStorageResult.FileName,
                    FullFilePath = fileStorageResult.FullFilePath,
                    ThumbnailFileName = fileStorageResult.ThumbnailFileName,
                    ThumbnailFullFilePath = fileStorageResult.ThumbnailFullFilePath,
                    StorageTypeID = fileStorageResult.FileSourceId,
                };

                this.Repository.Update(fileUpdate);

                transaction.Complete();
            }

            var getById = this.Repository.GetById(fileInsertResult.Bag.Id);
            result.Bag = new FileInsertCommandOutputDTO
            {
                Id = getById.Bag.Id
            };

            return result;

        }
    }
}

