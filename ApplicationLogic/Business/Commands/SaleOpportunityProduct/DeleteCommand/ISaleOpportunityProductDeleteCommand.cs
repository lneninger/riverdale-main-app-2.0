using ApplicationLogic.Business.Commands.SaleOpportunityProduct.DeleteCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityProduct.DeleteCommand
{
    public interface ISaleOpportunityProductDeleteCommand : ICommandFunc<int, OperationResponse<SaleOpportunityProductDeleteCommandOutputDTO>>
    {
    }
}