using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.GetAllCommand
{
    public interface ISampleBoxProductGetAllCommand : ICommandAction<OperationResponse<IEnumerable<SampleBoxProductGetAllCommandOutputDTO>>>
    {
    }
}