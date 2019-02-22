using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.PageQueryCommand
{
    public interface ISaleOpportunityPriceLevelPageQueryCommand : ICommandFunc<PageQuery<SaleOpportunityPriceLevelPageQueryCommandInputDTO>, OperationResponse<PageResult<SaleOpportunityPriceLevelPageQueryCommandOutputDTO>>>
    {
    }
}