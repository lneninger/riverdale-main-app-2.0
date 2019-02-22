using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.InsertCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.InsertCommand
{
    public interface ISaleOpportunityPriceLevelProductInsertCommand : ICommandFunc<SaleOpportunityPriceLevelProductInsertCommandInputDTO, OperationResponse<SaleOpportunityPriceLevelProductInsertCommandOutputDTO>>
    {
    }
}