using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.PageQueryCommand
{
    public interface IProductCategoryAllowedSizePageQueryCommand: ICommandFunc<PageQuery<ProductCategoryAllowedSizePageQueryCommandInputDTO>, OperationResponse<PageResult<ProductCategoryAllowedSizePageQueryCommandOutputDTO>>>
    {
    }
}