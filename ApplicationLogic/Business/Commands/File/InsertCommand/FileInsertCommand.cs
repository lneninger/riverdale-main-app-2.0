using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.File.InsertCommand.Models;
using Framework.Storage.DataHolders.Messages;

namespace ApplicationLogic.Business.Commands.File.InsertCommand
{
    public class FileInsertCommand : AbstractDBCommand<DomainModel.File.File, IFileDBRepository>, IFileInsertCommand
    {
        public FileInsertCommand(IDbContextScopeFactory dbContextScopeFactory, IFileDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<FileInsertCommandOutputDTO> Execute(FileInsertCommandInputDTO input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.Insert(input);
            }
        }
    }
}
