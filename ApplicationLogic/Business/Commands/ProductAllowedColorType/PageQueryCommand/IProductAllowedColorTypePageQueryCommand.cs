using ApplicationLogic.Business.Commands.ProductAllowedColorType.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductAllowedColorType.PageQueryCommand
{
    public interface IProductAllowedColorTypePageQueryCommand: ICommandFunc<PageQuery<ProductAllowedColorTypePageQueryCommandInputDTO>, OperationResponse<PageResult<ProductAllowedColorTypePageQueryCommandOutputDTO>>>
    {
    }
}