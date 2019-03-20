using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.GetByIdCommand.Models;
using Framework.Core.Messages;
using System;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.GetByIdCommand
{
    public interface ISaleOpportunityTargetPriceProductGetByIdCommand : ICommandFunc<int, OperationResponse<SaleOpportunityTargetPriceProductGetByIdCommandOutputDTO>>
    {
    }
}