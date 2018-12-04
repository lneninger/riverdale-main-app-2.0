using ApplicationLogic.Business.Commands.AppUserRole.UpdateCommand.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.AppUserRole.UpdateCommand
{
    public interface IAppUserRoleUpdateCommand: ICommandFunc<AppUserRoleUpdateCommandInputDTO, AppUserRoleUpdateCommandOutputDTO>
    {
    }
}