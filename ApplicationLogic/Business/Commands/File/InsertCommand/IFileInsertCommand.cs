using ApplicationLogic.Business.Commands.File.InsertCommand.Models;
using Framework.Storage.DataHolders.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.File.InsertCommand
{
    public interface IFileInsertCommand: ICommandFunc<FileInsertCommandInputDTO, OperationResponse<FileInsertCommandOutputDTO>>
    {
    }
}