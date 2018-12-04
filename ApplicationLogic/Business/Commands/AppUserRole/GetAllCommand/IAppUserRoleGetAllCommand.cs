using ApplicationLogic.Business.Commands.AppUserRole.GetAllCommand.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.AppUserRole.GetAllCommand
{
    public interface IAppUserRoleGetAllCommand: ICommandAction<IEnumerable<AppUserRoleGetAllCommandOutputDTO>>
    {
    }
}