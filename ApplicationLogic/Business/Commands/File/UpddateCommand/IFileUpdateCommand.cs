using ApplicationLogic.Business.Commands.File.UpdateCommand.Models;
using Framework.Storage.DataHolders.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.File.UpdateCommand
{
    public interface IFileUpdateCommand: ICommandFunc<FileUpdateCommandInputDTO, OperationResponse<FileUpdateCommandOutputDTO>>
    {
    }
}