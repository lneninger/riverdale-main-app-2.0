using ApplicationLogic.Business.Commands.SaleOpportunityProduct.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityProduct.GetAllCommand
{
    public interface ISaleOpportunityProductGetAllCommand : ICommandAction<OperationResponse<IEnumerable<SaleOpportunityProductGetAllCommandOutputDTO>>>
    {
    }
}