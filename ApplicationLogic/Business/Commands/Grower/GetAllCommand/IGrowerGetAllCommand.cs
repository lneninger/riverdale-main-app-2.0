using ApplicationLogic.Business.Commands.Grower.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Grower.GetAllCommand
{
    public interface IGrowerGetAllCommand: ICommandAction<OperationResponse<IEnumerable<GrowerGetAllCommandOutputDTO>>>
    {
    }
}