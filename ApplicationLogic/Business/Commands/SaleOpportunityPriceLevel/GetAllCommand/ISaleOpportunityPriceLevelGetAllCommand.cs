using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.GetAllCommand
{
    public interface ISaleOpportunityPriceLevelGetAllCommand : ICommandAction<OperationResponse<IEnumerable<SaleOpportunityPriceLevelGetAllCommandOutputDTO>>>
    {
    }
}