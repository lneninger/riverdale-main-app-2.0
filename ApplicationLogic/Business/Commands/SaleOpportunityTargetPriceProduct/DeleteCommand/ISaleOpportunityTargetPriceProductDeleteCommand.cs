using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.DeleteCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.DeleteCommand
{
    public interface ISaleOpportunityTargetPriceProductDeleteCommand : ICommandFunc<int, OperationResponse<SaleOpportunityTargetPriceProductDeleteCommandOutputDTO>>
    {
    }
}