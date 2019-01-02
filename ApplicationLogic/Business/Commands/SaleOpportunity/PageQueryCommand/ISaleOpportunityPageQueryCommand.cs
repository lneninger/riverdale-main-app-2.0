using ApplicationLogic.Business.Commands.SaleOpportunity.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunity.PageQueryCommand
{
    public interface ISaleOpportunityPageQueryCommand: ICommandFunc<PageQuery<SaleOpportunityPageQueryCommandInputDTO>, OperationResponse<PageResult<SaleOpportunityPageQueryCommandOutputDTO>>>
    {
    }
}