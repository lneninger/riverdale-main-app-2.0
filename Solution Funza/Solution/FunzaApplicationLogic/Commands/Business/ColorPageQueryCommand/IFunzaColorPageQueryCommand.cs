using FunzaApplicationLogic.Commands.Funza.ColorPageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace FunzaApplicationLogic.Commands.Funza.ColorPageQueryCommand
{
    public interface IFunzaColorPageQueryCommand: ICommandFunc<PageQuery<ColorPageQueryCommandInput>, OperationResponse<PageResult<ColorPageQueryCommandOutput>>>
    {
    }
}