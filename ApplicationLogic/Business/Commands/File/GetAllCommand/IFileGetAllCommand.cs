using ApplicationLogic.Business.Commands.File.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.File.GetAllCommand
{
    public interface IFileGetAllCommand: ICommandAction<OperationResponse<IEnumerable<FileGetAllCommandOutputDTO>>>
    {
    }
}