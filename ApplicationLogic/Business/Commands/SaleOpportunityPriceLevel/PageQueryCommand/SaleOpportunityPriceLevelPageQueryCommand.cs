using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.PageQueryCommand
{
    public class SaleOpportunityPriceLevelPageQueryCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SaleOpportunityPriceLevel, ISaleOpportunityPriceLevelDBRepository>, ISaleOpportunityPriceLevelPageQueryCommand
    {
        public SaleOpportunityPriceLevelPageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityPriceLevelDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<PageResult<SaleOpportunityPriceLevelPageQueryCommandOutputDTO>> Execute(PageQuery<SaleOpportunityPriceLevelPageQueryCommandInputDTO> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}
