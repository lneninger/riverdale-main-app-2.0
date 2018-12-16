using ApplicationLogic.Business.Commands.ProductMedia.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Storage.DataHolders.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductMedia.PageQueryCommand
{
    public interface IProductMediaPageQueryCommand: ICommandFunc<PageQuery<ProductMediaPageQueryCommandInputDTO>, OperationResponse<PageResult<ProductMediaPageQueryCommandOutputDTO>>>
    {
    }
}