using ApplicationLogic.Business.Commands.SaleOpportunity.DeleteCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunity.DeleteCommand
{
    public interface ISaleOpportunityDeleteCommand: ICommandFunc<int, OperationResponse<SaleOpportunityDeleteCommandOutputDTO>>
    {
    }
}