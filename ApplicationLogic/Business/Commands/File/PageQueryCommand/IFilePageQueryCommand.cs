using ApplicationLogic.Business.Commands.File.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Storage.DataHolders.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.File.PageQueryCommand
{
    public interface IFilePageQueryCommand: ICommandFunc<PageQuery<FilePageQueryCommandInputDTO>, OperationResponse<PageResult<FilePageQueryCommandOutputDTO>>>
    {
    }
}