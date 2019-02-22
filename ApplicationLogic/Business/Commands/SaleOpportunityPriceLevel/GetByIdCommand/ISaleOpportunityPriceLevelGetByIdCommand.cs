using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.GetByIdCommand.Models;
using Framework.Core.Messages;
using System;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.GetByIdCommand
{
    public interface ISaleOpportunityPriceLevelGetByIdCommand : ICommandFunc<int, OperationResponse<SaleOpportunityPriceLevelGetByIdCommandOutputDTO>>
    {
    }
}