using ApplicationLogic.Business.Commands.Product.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Funza.PageQueryCommand
{
    public interface IProductPageQueryCommand: ICommandFunc<PageQuery<ProductPageQueryCommandInputDTO>, OperationResponse<PageResult<ProductPageQueryCommandOutputDTO>>>
    {
    }
}