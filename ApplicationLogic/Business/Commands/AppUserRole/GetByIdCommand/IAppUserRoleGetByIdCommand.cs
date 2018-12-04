using ApplicationLogic.Business.Commands.AppUserRole.GetByIdCommand.Models;
using System;

namespace ApplicationLogic.Business.Commands.AppUserRole.GetByIdCommand
{
    public interface IAppUserRoleGetByIdCommand: ICommandFunc<string, AppUserRoleGetByIdCommandOutputDTO>
    {
    }
}