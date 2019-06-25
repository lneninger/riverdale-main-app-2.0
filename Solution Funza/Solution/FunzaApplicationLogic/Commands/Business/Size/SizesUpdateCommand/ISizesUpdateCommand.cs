using FunzaApplicationLogic.Commands.Size.SizeUpdateCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;
using Framework.Commands;
using FunzaApplicationLogic.Commands.Business.SyncCommand.Models;

namespace FunzaApplicationLogic.Commands.Funza.Size.SizesUpdateCommand
{
    public interface ISizesUpdateCommand: ICommandFunc<SyncCommandEntityWrapperInput<SizesUpdateCommandInput>, OperationResponse<SizesUpdateCommandOutput>>
    {
    }
}