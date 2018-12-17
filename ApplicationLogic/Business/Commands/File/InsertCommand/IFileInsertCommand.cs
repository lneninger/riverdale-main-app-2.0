using ApplicationLogic.Business.Commands.File.InsertCommand.Models;
using Framework.Storage.DataHolders.Messages;
using Framework.Storage.FileStorage.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.File.InsertCommand
{
    public interface IFileInsertCommand: ICommandFunc<FileInsertCommandInputDTO, OperationResponse<FileInsertCommandOutputDTO>>
    {
        OperationResponse<FileInsertCommandOutputDTO> Execute<T>(T input) where T : FileArgs;
    }
}