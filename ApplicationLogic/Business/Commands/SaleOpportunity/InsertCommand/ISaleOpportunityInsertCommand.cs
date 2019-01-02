using ApplicationLogic.Business.Commands.SaleOpportunity.InsertCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunity.InsertCommand
{
    public interface ISaleOpportunityInsertCommand: ICommandFunc<SaleOpportunityInsertCommandInputDTO, OperationResponse<SaleOpportunityInsertCommandOutputDTO>>
    {
    }
}