using ApplicationLogic.Business.Commands.Grower.InsertCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Grower.InsertCommand
{
    public interface IGrowerInsertCommand: ICommandFunc<GrowerInsertCommandInputDTO, OperationResponse<GrowerInsertCommandOutputDTO>>
    {
    }
}