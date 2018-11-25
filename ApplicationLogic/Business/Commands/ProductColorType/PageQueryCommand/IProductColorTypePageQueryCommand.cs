using ApplicationLogic.Business.Commands.ProductColorType.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductColorType.PageQueryCommand
{
    public interface IProductColorTypePageQueryCommand: ICommandFunc<PageQuery<ProductColorTypePageQueryCommandInputDTO>, PageResult<ProductColorTypePageQueryCommandOutputDTO>>
    {
    }
}