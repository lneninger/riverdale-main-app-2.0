using ApplicationLogic.Business.Commands.SaleOpportunityProduct.UpdateCommand.Models;

using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityProduct.UpdateCommand
{
    public interface ISaleOpportunityProductUpdateCommand : ICommandFunc<SaleOpportunityProductUpdateCommandInputDTO, OperationResponse<SaleOpportunityProductUpdateCommandOutputDTO>>
    {
    }
}