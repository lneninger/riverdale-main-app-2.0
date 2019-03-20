using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.PageQueryCommand
{
    public class SaleOpportunityTargetPricePageQueryCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SaleOpportunityTargetPrice, ISaleOpportunityTargetPriceDBRepository>, ISaleOpportunityTargetPricePageQueryCommand
    {
        public SaleOpportunityTargetPricePageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityTargetPriceDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<PageResult<SaleOpportunityTargetPricePageQueryCommandOutputDTO>> Execute(PageQuery<SaleOpportunityTargetPricePageQueryCommandInputDTO> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}
