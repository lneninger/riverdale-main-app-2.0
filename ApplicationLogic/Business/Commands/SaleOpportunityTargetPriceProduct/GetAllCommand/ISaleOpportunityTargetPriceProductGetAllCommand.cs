using ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPriceProduct.GetAllCommand
{
    public interface ISaleOpportunityTargetPriceProductGetAllCommand : ICommandAction<OperationResponse<IEnumerable<SaleOpportunityTargetPriceProductGetAllCommandOutputDTO>>>
    {
    }
}