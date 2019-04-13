using ApplicationLogic.Business.Commands.ProductCategory.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductCategory.PageQueryCommand
{
    public interface IProductCategoryPageQueryCommand: ICommandFunc<PageQuery<ProductCategoryPageQueryCommandInputDTO>, OperationResponse<PageResult<ProductCategoryPageQueryCommandOutputDTO>>>
    {
    }
}