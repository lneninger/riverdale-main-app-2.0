using ApplicationLogic.Business.Commands.File.InsertCommand.Models;
using Framework.Core.Messages;
using Framework.Storage.FileStorage.Models;
using Framework.Storage.FileStorage.TemporaryStorage;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.File.InsertCommand
{
    public interface IFileInsertCommand/*: ICommandFunc<FileInsertCommandInputDTO, OperationResponse<FileInsertCommandOutputDTO>>*/
    {
        OperationResponse<FileInsertCommandOutputDTO> Execute<T, A>(T input) where T : FileArgs<A> where A : UploadedFile;
    }
}