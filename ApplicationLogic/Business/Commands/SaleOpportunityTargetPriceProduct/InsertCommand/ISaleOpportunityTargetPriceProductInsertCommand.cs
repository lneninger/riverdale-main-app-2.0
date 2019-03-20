using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.InsertCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.InsertCommand
{
    public interface ISaleOpportunityTargetPriceProductInsertCommand : ICommandFunc<SaleOpportunityTargetPriceProductInsertCommandInputDTO, OperationResponse<SaleOpportunityTargetPriceProductInsertCommandOutputDTO>>
    {
    }
}