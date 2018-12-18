using ApplicationLogic.Business.Commands.File.UpdateCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.File.UpdateCommand
{
    public interface IFileUpdateCommand: ICommandFunc<FileUpdateCommandInputDTO, OperationResponse<FileUpdateCommandOutputDTO>>
    {
    }
}