using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.UpdateCommand.Models;

using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.UpdateCommand
{
    public interface ISaleOpportunityPriceLevelUpdateCommand : ICommandFunc<SaleOpportunityPriceLevelUpdateCommandInputDTO, OperationResponse<SaleOpportunityPriceLevelUpdateCommandOutputDTO>>
    {
    }
}