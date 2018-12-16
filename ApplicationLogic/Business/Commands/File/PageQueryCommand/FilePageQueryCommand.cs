using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.File.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Storage.DataHolders.Messages;

namespace ApplicationLogic.Business.Commands.File.PageQueryCommand
{
    public class FilePageQueryCommand : AbstractDBCommand<DomainModel.File.File, IFileDBRepository>, IFilePageQueryCommand
    {
        public FilePageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, IFileDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<PageResult<FilePageQueryCommandOutputDTO>> Execute(PageQuery<FilePageQueryCommandInputDTO> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}
