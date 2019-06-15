using Framework.Commands;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace FunzaApplicationLogic.Commands.SyncCommand
{
    public interface IFunzaSyncCommand : ICommandActionAsync<OperationResponse>
    {
    }
}