using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using Framework.Core.Messages;
using Framework.Storage.FileStorage.TemporaryStorage;
using Framework.FileStorage.AspNetCore.FileStorage.Models;
using ApplicationLogic.Business.Commands.File.FileRetrieverCommand.Models;

namespace ApplicationLogic.Business.Commands.File.FileRetrieverCommand
{
    public class FileRetrieverCommand : AbstractDBCommand<DomainModel.File.File, IFileDBRepository>, IFileRetriever
    {

        public FileRetrieverCommand(IDbContextScopeFactory dbContextScopeFactory, IFileDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<IFileData> DeleteFile(object identifier)
        {
            var result = new OperationResponse<IFileData>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.Delete((int)identifier);
                result.AddResponse(getByIdResult);
            }

            return result;
        }

        public OperationResponse<IFileData> GetFileData(object identifier)
        {
            var result = new OperationResponse<IFileData>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById((int)identifier);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {

                    result.Bag = new FileRetrieverCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                        RootPath = getByIdResult.Bag.RootPath,
                        AccessPath = getByIdResult.Bag.AccessPath,
                        RelativePath = getByIdResult.Bag.RelativePath,
                        ThumbnailFileName = getByIdResult.Bag.ThumbnailFileName,
                        FileName = getByIdResult.Bag.FileName,
                        FileSystemTypeId = getByIdResult.Bag.FileSystemTypeId,
                        ThumbnailFullFilePath = getByIdResult.Bag.ThumbnailFullFilePath,
                        FullFilePath = getByIdResult.Bag.FullFilePath,

                    };
                }
            }

            return result;
        }
    }
}
