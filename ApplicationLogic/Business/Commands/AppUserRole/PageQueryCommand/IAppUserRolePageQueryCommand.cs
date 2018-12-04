using ApplicationLogic.Business.Commands.AppUserRole.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.AppUserRole.PageQueryCommand
{
    public interface IAppUserRolePageQueryCommand: ICommandFunc<PageQuery<AppUserRolePageQueryCommandInputDTO>, PageResult<AppUserRolePageQueryCommandOutputDTO>>
    {
    }
}