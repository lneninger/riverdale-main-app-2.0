using ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.UpdateCommand.Models;

using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.UpdateCommand
{
    public interface ISaleOpportunityTargetPriceUpdateCommand : ICommandFunc<SaleOpportunityTargetPriceUpdateCommandInputDTO, OperationResponse<SaleOpportunityTargetPriceUpdateCommandOutputDTO>>
    {
    }
}