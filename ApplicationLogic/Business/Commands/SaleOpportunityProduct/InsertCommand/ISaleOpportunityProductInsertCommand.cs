using ApplicationLogic.Business.Commands.SaleOpportunityProduct.InsertCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityProduct.InsertCommand
{
    public interface ISaleOpportunityProductInsertCommand : ICommandFunc<SaleOpportunityProductInsertCommandInputDTO, OperationResponse<SaleOpportunityProductInsertCommandOutputDTO>>
    {
    }
}