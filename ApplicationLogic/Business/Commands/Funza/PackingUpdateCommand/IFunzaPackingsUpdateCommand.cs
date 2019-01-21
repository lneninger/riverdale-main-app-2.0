using ApplicationLogic.Business.Commands.Funza.PackingsUpdateCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Funza.PackingsUpdateCommand.Models
{
    public interface IFunzaPackingsUpdateCommand : ICommandFunc<IEnumerable<FunzaPackingsUpdateCommandInputDTO>, OperationResponse<FunzaPackingsUpdateCommandOutputDTO>>
    {
    }
}