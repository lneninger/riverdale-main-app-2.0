using ApplicationLogic.Business.Commands.AppUser.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Storage.DataHolders.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.AppUser.PageQueryCommand
{
    public interface IAppUserPageQueryCommand: ICommandFunc<PageQuery<AppUserPageQueryCommandInputDTO>, OperationResponse<PageResult<AppUserPageQueryCommandOutputDTO>>>
    {
    }
}