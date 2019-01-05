using ApplicationLogic.Business.Commands.SaleOpportunityProduct.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityProduct.PageQueryCommand
{
    public interface ISaleOpportunityProductPageQueryCommand : ICommandFunc<PageQuery<SaleOpportunityProductPageQueryCommandInputDTO>, OperationResponse<PageResult<SaleOpportunityProductPageQueryCommandOutputDTO>>>
    {
    }
}