using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.UpdateCommand.Models;

using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.UpdateCommand
{
    public interface ISaleOpportunityTargetPriceProductUpdateCommand : ICommandFunc<SaleOpportunityTargetPriceProductUpdateCommandInputDTO, OperationResponse<SaleOpportunityTargetPriceProductUpdateCommandOutputDTO>>
    {
    }
}