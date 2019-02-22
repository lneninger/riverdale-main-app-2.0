using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.GetByIdCommand.Models;
using Framework.Core.Messages;
using System;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.GetByIdCommand
{
    public interface ISaleOpportunityPriceLevelProductGetByIdCommand : ICommandFunc<int, OperationResponse<SaleOpportunityPriceLevelProductGetByIdCommandOutputDTO>>
    {
    }
}