using System;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.File.GetByIdCommand.Models;
using Framework.Storage.DataHolders.Messages;

namespace ApplicationLogic.Business.Commands.File.GetByIdCommand
{
    public class FileGetByIdCommand : AbstractDBCommand<DomainModel.File.File, IFileDBRepository>, IFileGetByIdCommand
    {

        public FileGetByIdCommand(IDbContextScopeFactory dbContextScopeFactory, IFileDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<FileGetByIdCommandOutputDTO> Execute(int id)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetById(id);
            }
        }
    }
}
