using ApplicationLogic.Business.Commands.Grower.DeleteCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Grower.DeleteCommand
{
    public interface IGrowerDeleteCommand: ICommandFunc<int, OperationResponse<GrowerDeleteCommandOutputDTO>>
    {
    }
}