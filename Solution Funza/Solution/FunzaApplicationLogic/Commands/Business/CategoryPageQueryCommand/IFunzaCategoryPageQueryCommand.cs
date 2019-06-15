using FunzaApplicationLogic.Commands.Funza.CategoryPageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace FunzaApplicationLogic.Commands.Funza.CategoryPageQueryCommand
{
    public interface IFunzaCategoryPageQueryCommand: ICommandFunc<PageQuery<CategoryPageQueryCommandInput>, OperationResponse<PageResult<CategoryPageQueryCommandOutput>>>
    {
    }
}