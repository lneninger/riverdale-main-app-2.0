using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.UpdateCommand.Models;

using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.UpdateCommand
{
    public interface ISaleOpportunityPriceLevelProductUpdateCommand : ICommandFunc<SaleOpportunityPriceLevelProductUpdateCommandInputDTO, OperationResponse<SaleOpportunityPriceLevelProductUpdateCommandOutputDTO>>
    {
    }
}