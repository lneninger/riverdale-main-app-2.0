using ApplicationLogic.Business.Commands.File.DeleteCommand.Models;
using Framework.Storage.DataHolders.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.File.DeleteCommand
{
    public interface IFileDeleteCommand: ICommandFunc<int, OperationResponse<FileDeleteCommandOutputDTO>>
    {
    }
}