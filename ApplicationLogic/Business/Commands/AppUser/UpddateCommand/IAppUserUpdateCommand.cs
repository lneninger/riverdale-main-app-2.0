using ApplicationLogic.Business.Commands.AppUser.UpdateCommand.Models;
using Framework.Storage.DataHolders.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.AppUser.UpdateCommand
{
    public interface IAppUserUpdateCommand: ICommandFunc<AppUserUpdateCommandInputDTO, OperationResponse<AppUserUpdateCommandOutputDTO>>
    {
    }
}