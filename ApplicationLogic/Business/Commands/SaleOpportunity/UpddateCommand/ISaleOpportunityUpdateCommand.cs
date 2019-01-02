using ApplicationLogic.Business.Commands.SaleOpportunity.UpdateCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunity.UpdateCommand
{
    public interface ISaleOpportunityUpdateCommand: ICommandFunc<SaleOpportunityUpdateCommandInputDTO, OperationResponse<SaleOpportunityUpdateCommandOutputDTO>>
    {
    }
}