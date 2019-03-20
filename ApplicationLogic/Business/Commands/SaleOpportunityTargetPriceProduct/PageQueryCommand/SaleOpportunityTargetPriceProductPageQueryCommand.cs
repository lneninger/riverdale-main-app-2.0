using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.PageQueryCommand
{
    public class SaleOpportunityTargetPriceProductPageQueryCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SaleOpportunityTargetPriceProduct, ISaleOpportunityTargetPriceProductDBRepository>, ISaleOpportunityTargetPriceProductPageQueryCommand
    {
        public SaleOpportunityTargetPriceProductPageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, ISaleOpportunityTargetPriceProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<PageResult<SaleOpportunityTargetPriceProductPageQueryCommandOutputDTO>> Execute(PageQuery<SaleOpportunityTargetPriceProductPageQueryCommandInputDTO> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}
