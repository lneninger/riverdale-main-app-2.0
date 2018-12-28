using ApplicationLogic.Business.Commands.ProductBridge.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductBridge.PageQueryCommand
{
    public interface IProductBridgePageQueryCommand : ICommandFunc<PageQuery<ProductBridgePageQueryCommandInputDTO>, OperationResponse<PageResult<ProductBridgePageQueryCommandOutputDTO>>>
    {
    }
}