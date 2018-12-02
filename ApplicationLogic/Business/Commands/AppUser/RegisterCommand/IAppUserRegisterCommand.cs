using ApplicationLogic.Business.Commands.AppUser.RegisterCommand.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.AppUser.RegisterCommand
{
    public interface IAppUserRegisterCommand: ICommandFunc<AppUserRegisterCommandInputDTO, AppUserRegisterCommandOutputDTO>
    {
    }
}