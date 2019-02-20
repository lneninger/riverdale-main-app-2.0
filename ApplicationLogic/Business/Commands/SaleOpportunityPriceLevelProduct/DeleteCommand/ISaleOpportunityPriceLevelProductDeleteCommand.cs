using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.DeleteCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.DeleteCommand
{
    public interface ISaleOpportunityPriceLevelProductDeleteCommand : ICommandFunc<int, OperationResponse<SaleOpportunityPriceLevelProductDeleteCommandOutputDTO>>
    {
    }
}