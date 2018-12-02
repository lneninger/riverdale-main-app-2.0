using ApplicationLogic.Business.Commands.AppUser.UpdateCommand.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.AppUser.UpdateCommand
{
    public interface IAppUserUpdateCommand: ICommandFunc<AppUserUpdateCommandInputDTO, AppUserUpdateCommandOutputDTO>
    {
    }
}