using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityProduct.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.SaleOpportunityProduct.PageQueryCommand
{
    public class SaleOpportunityProductPageQueryCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SaleOpportunityProduct, ISaleOpportunityProductDBRepository>, ISaleOpportunityProductPageQueryCommand
    {
        public SaleOpportunityProductPageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<PageResult<SaleOpportunityProductPageQueryCommandOutputDTO>> Execute(PageQuery<SaleOpportunityProductPageQueryCommandInputDTO> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}
