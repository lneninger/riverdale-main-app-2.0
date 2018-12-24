using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.File.GetByIdCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.File.GetByIdCommand
{
    public class FileGetByIdCommand : AbstractDBCommand<DomainModel.File.File, IFileDBRepository>, IFileGetByIdCommand
    {

        public FileGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, IFileDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<FileGetByIdCommandOutputDTO> Execute(int id)
        {
            var result = new OperationResponse<FileGetByIdCommandOutputDTO>();
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                var getByIdResult = this.Repository.GetById(id);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new FileGetByIdCommandOutputDTO
                    {
                        Id = getByIdResult.Bag.Id,
                    };
                }
            }

            return result;
        }
    }
}
