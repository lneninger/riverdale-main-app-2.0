using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.File.DeleteCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.File.DeleteCommand
{
    public class FileDeleteCommand : AbstractDBCommand<DomainModel.File.File, IFileDBRepository>, IFileDeleteCommand
    {
        public FileDeleteCommand(IDbContextScopeFactory dbContextScopeFactory, IFileDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<FileDeleteCommandOutputDTO> Execute(int id)
        {
            return this.Repository.Delete(id);
        }
    }
}
