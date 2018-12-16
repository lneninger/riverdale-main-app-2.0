using ApplicationLogic.Business.Commands.File.GetByIdCommand.Models;
using Framework.Storage.DataHolders.Messages;
using System;

namespace ApplicationLogic.Business.Commands.File.GetByIdCommand
{
    public interface IFileGetByIdCommand: ICommandFunc<int, OperationResponse<FileGetByIdCommandOutputDTO>>
    {
    }
}