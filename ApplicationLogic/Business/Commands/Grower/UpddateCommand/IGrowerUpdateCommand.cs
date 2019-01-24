using ApplicationLogic.Business.Commands.Grower.UpdateCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Grower.UpdateCommand
{
    public interface IGrowerUpdateCommand: ICommandFunc<GrowerUpdateCommandInputDTO, OperationResponse<GrowerUpdateCommandOutputDTO>>
    {
    }
}