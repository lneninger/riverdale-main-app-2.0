using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Funza.PackingPageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.Funza.PackingPageQueryCommand
{
    public class FunzaPackingPageQueryCommand : AbstractDBCommand<DomainModel.Funza.PackingReference, IFunzaPackingReferenceDBRepository>, IFunzaPackingPageQueryCommand
    {
        public FunzaPackingPageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, IFunzaPackingReferenceDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<PageResult<FunzaPackingPageQueryCommandOutputDTO>> Execute(PageQuery<FunzaPackingPageQueryCommandInputDTO> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}
