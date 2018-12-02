using ApplicationLogic.Business.Commands.AppUser.GetAllCommand.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.AppUser.GetAllCommand
{
    public interface IAppUserGetAllCommand: ICommandAction<IEnumerable<AppUserGetAllCommandOutputDTO>>
    {
    }
}