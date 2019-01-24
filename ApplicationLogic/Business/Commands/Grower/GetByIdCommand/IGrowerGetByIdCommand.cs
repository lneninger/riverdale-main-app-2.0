using ApplicationLogic.Business.Commands.Grower.GetByIdCommand.Models;
using Framework.Core.Messages;
using System;

namespace ApplicationLogic.Business.Commands.Grower.GetByIdCommand
{
    public interface IGrowerGetByIdCommand: ICommandFunc<int, OperationResponse<GrowerGetByIdCommandOutputDTO>>
    {
    }
}