using ApplicationLogic.Business.Commands.SaleOpportunity.GetByIdCommand.Models;
using Framework.Core.Messages;
using System;

namespace ApplicationLogic.Business.Commands.SaleOpportunity.GetByIdCommand
{
    public interface ISaleOpportunityGetByIdCommand: ICommandFunc<int, OperationResponse<SaleOpportunityGetByIdCommandOutputDTO>>
    {
    }
}