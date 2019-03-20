using ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.GetAllCommand
{
    public interface ISaleOpportunityTargetPriceGetAllCommand : ICommandAction<OperationResponse<IEnumerable<SaleOpportunityTargetPriceGetAllCommandOutputDTO>>>
    {
    }
}