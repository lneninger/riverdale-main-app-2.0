using FunzaApplicationLogic.Commands.Funza.ProductPageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;
using Framework.Commands;

namespace FunzaApplicationLogic.Commands.Funza.ProductPageQueryCommand
{
    public interface IFunzaProductPageQueryCommand: ICommandFunc<PageQuery<ProductPageQueryCommandInput>, OperationResponse<PageResult<ProductPageQueryCommandOutput>>>
    {
    }
}