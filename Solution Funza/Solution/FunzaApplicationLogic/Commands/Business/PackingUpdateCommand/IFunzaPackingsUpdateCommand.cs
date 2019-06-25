using FunzaApplicationLogic.Commands.Funza.PackingsUpdateCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;
using Framework.Commands;
using FunzaApplicationLogic.Commands.Business.SyncCommand.Models;

namespace FunzaApplicationLogic.Commands.Funza.PackingsUpdateCommand.Models
{
    public interface IFunzaPackingsUpdateCommand : ICommandFunc<SyncCommandEntityWrapperInput<PackingsUpdateCommandInput>, OperationResponse<PackingsUpdateCommandOutput>>
    {
    }
}