using ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.PageQueryCommand
{
    public interface ISaleOpportunityTargetPricePageQueryCommand : ICommandFunc<PageQuery<SaleOpportunityTargetPricePageQueryCommandInputDTO>, OperationResponse<PageResult<SaleOpportunityTargetPricePageQueryCommandOutputDTO>>>
    {
    }
}