using FunzaApplicationLogic.Commands.Funza.PackingsUpdateCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace FunzaApplicationLogic.Commands.Funza.PackingsUpdateCommand.Models
{
    public interface IFunzaPackingsUpdateCommand : ICommandFunc<IEnumerable<PackingsUpdateCommandInput>, OperationResponse<PackingsUpdateCommandOutput>>
    {
    }
}