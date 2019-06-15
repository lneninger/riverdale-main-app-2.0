using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using FunzaApplicationLogic.Commands.Funza.PackingPageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;

namespace FunzaApplicationLogic.Commands.Funza.PackingPageQueryCommand
{
    public class FunzaPackingPageQueryCommand : AbstractDBCommand<DomainModel.Funza.Packing, IPackingDBRepository>, IFunzaPackingPageQueryCommand
    {
        public FunzaPackingPageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, IPackingDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<PageResult<PackingPageQueryCommandOutput>> Execute(PageQuery<PackingPageQueryCommandInput> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}
