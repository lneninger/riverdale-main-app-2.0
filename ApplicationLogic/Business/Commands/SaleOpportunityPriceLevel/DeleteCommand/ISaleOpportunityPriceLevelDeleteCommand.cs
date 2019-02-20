using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.DeleteCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.DeleteCommand
{
    public interface ISaleOpportunityPriceLevelDeleteCommand : ICommandFunc<int, OperationResponse<SaleOpportunityPriceLevelDeleteCommandOutputDTO>>
    {
    }
}