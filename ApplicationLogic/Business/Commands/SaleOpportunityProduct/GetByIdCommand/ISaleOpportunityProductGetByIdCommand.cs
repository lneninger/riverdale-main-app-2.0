using ApplicationLogic.Business.Commands.SaleOpportunityProduct.GetByIdCommand.Models;
using Framework.Core.Messages;
using System;

namespace ApplicationLogic.Business.Commands.SaleOpportunityProduct.GetByIdCommand
{
    public interface ISaleOpportunityProductGetByIdCommand : ICommandFunc<int, OperationResponse<SaleOpportunityProductGetByIdCommandOutputDTO>>
    {
    }
}