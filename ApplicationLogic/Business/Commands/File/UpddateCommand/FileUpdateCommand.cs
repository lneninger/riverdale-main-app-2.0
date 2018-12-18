using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.File.UpdateCommand.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.File.UpdateCommand
{
    public class FileUpdateCommand : AbstractDBCommand<DomainModel.File.File, IFileDBRepository>, IFileUpdateCommand
    {
        public FileUpdateCommand(IDbContextScopeFactory dbContextScopeFactory, IFileDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<FileUpdateCommandOutputDTO> Execute(FileUpdateCommandInputDTO input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.Update(input);
            }
        }
    }
}
