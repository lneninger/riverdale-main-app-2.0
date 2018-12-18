using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.File.GetAllCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.File.GetAllCommand
{
    public class FileGetAllCommand : AbstractDBCommand<DomainModel.File.File, IFileDBRepository>, IFileGetAllCommand
    {
        public FileGetAllCommand(IDbContextScopeFactory dbContextScopeFactory, IFileDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<IEnumerable<FileGetAllCommandOutputDTO>> Execute()
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetAll();
            }
        }
    }
}
