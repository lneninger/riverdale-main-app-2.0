using ApplicationLogic.Business.Commands.AppUser.GetByIdCommand.Models;
using System;

namespace ApplicationLogic.Business.Commands.AppUser.GetByIdCommand
{
    public interface IAppUserGetByIdCommand: ICommandFunc<string, AppUserGetByIdCommandOutputDTO>
    {
    }
}