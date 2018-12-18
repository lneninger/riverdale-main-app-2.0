using ApplicationLogic.Business.Commands.ProductColorType.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductColorType.PageQueryCommand
{
    public interface IProductColorTypePageQueryCommand: ICommandFunc<PageQuery<ProductColorTypePageQueryCommandInputDTO>, OperationResponse<PageResult<ProductColorTypePageQueryCommandOutputDTO>>>
    {
    }
}