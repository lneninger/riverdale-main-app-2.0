using FunzaApplicationLogic.Commands.Funza.PackingPageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;
using Framework.Commands;

namespace FunzaApplicationLogic.Commands.Funza.PackingPageQueryCommand
{
    public interface IFunzaPackingPageQueryCommand: ICommandFunc<PageQuery<PackingPageQueryCommandInput>, OperationResponse<PageResult<PackingPageQueryCommandOutput>>>
    {
    }
}