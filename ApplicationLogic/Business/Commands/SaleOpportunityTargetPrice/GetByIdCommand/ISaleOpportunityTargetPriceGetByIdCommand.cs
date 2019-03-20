using ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.GetByIdCommand.Models;
using Framework.Core.Messages;
using System;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.GetByIdCommand
{
    public interface ISaleOpportunityTargetPriceGetByIdCommand : ICommandFunc<int, OperationResponse<SaleOpportunityTargetPriceGetByIdCommandOutputDTO>>
    {
    }
}