using FunzaApplicationLogic.Commands.Funza.CategoriesUpdateCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;
using Framework.Commands;
using FunzaApplicationLogic.Commands.Business.SyncCommand.Models;

namespace FunzaApplicationLogic.Commands.Funza.CategoriesUpdateCommand.Models
{
    public interface IFunzaCategoriesUpdateCommand: ICommandFunc<SyncCommandEntityWrapperInput<CategoriesUpdateCommandInput>, OperationResponse<CategoriesUpdateCommandOutput>>
    {
    }
}