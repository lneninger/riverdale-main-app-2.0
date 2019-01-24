using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Funza.ColorPageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.Funza.ColorPageQueryCommand
{
    public class FunzaColorPageQueryCommand : AbstractDBCommand<DomainModel.Funza.ColorReference, IFunzaColorReferenceDBRepository>, IFunzaColorPageQueryCommand
    {
        public FunzaColorPageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, IFunzaColorReferenceDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<PageResult<FunzaColorPageQueryCommandOutputDTO>> Execute(PageQuery<FunzaColorPageQueryCommandInputDTO> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}
