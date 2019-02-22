using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevelProduct.PageQueryCommand
{
    public interface ISaleOpportunityPriceLevelProductPageQueryCommand : ICommandFunc<PageQuery<SaleOpportunityPriceLevelProductPageQueryCommandInputDTO>, OperationResponse<PageResult<SaleOpportunityPriceLevelProductPageQueryCommandOutputDTO>>>
    {
    }
}