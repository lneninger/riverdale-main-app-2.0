using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.InsertCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.InsertCommand
{
    public interface ISaleOpportunityPriceLevelInsertCommand : ICommandFunc<SaleOpportunityPriceLevelInsertCommandInputDTO, OperationResponse<SaleOpportunityPriceLevelInsertCommandOutputDTO>>
    {
    }
}