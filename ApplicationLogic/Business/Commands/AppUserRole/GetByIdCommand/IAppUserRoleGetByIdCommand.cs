﻿using ApplicationLogic.Business.Commands.AppUserRole.GetByIdCommand.Models;
using Framework.Storage.DataHolders.Messages;
using System;

namespace ApplicationLogic.Business.Commands.AppUserRole.GetByIdCommand
{
    public interface IAppUserRoleGetByIdCommand: ICommandFunc<string, OperationResponse<AppUserRoleGetByIdCommandOutputDTO>>
    {
    }
}