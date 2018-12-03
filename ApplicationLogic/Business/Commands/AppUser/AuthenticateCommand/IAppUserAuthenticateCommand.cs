using ApplicationLogic.Business.Commands.AppUser.AuthenticateCommand.Models;
using Framework.Storage.DataHolders.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.AppUser.AuthenticateCommand
{
    public interface IAppUserAuthenticateCommand : ICommandFunc<AppUserAuthenticateCommandInputDTO, OperationResponse<AppUserAuthenticateCommandOutputDTO>>
    {
    }
}