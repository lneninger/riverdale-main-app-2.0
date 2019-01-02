using ApplicationLogic.Business.Commands.SaleOpportunity.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunity.GetAllCommand
{
    public interface ISaleOpportunityGetAllCommand: ICommandAction<OperationResponse<IEnumerable<SaleOpportunityGetAllCommandOutputDTO>>>
    {
    }
}