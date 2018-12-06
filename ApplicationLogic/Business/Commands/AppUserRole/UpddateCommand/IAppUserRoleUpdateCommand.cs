using ApplicationLogic.Business.Commands.AppUserRole.UpdateCommand.Models;
using Framework.Storage.DataHolders.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.AppUserRole.UpdateCommand
{
    public interface IAppUserRoleUpdateCommand: ICommandFunc<AppUserRoleUpdateCommandInputDTO, OperationResponse<AppUserRoleUpdateCommandOutputDTO>>
    {
    }
}