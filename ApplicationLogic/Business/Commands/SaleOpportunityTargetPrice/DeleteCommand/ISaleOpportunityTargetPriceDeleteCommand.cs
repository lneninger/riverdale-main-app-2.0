using ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.DeleteCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.DeleteCommand
{
    public interface ISaleOpportunityTargetPriceDeleteCommand : ICommandFunc<int, OperationResponse<SaleOpportunityTargetPriceDeleteCommandOutputDTO>>
    {
    }
}