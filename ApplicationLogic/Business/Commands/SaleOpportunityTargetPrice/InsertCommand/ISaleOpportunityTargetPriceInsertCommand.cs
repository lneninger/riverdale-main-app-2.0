using ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.InsertCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.InsertCommand
{
    public interface ISaleOpportunityTargetPriceInsertCommand : ICommandFunc<SaleOpportunityTargetPriceInsertCommandInputDTO, OperationResponse<SaleOpportunityTargetPriceInsertCommandOutputDTO>>
    {
    }
}