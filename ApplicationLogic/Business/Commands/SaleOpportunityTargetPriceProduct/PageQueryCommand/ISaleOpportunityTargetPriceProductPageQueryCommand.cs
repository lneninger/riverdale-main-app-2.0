using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.PageQueryCommand
{
    public interface ISaleOpportunityTargetPriceProductPageQueryCommand : ICommandFunc<PageQuery<SaleOpportunityTargetPriceProductPageQueryCommandInputDTO>, OperationResponse<PageResult<SaleOpportunityTargetPriceProductPageQueryCommandOutputDTO>>>
    {
    }
}