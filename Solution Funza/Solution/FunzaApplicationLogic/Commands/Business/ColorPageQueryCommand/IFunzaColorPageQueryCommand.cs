using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;
using Framework.Commands;
using FunzaApplicationLogic.Commands.ColorPageQueryCommand.Models;

namespace FunzaApplicationLogic.Commands.Funza.ColorPageQueryCommand
{
    public interface IFunzaColorPageQueryCommand: ICommandFunc<PageQuery<ColorPageQueryCommandInput>, OperationResponse<PageResult<ColorPageQueryCommandOutput>>>
    {
    }
}