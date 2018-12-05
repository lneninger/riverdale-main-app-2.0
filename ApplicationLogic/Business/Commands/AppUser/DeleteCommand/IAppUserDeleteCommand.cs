﻿using ApplicationLogic.Business.Commands.AppUser.DeleteCommand.Models;
using Framework.Storage.DataHolders.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.AppUser.DeleteCommand
{
    public interface IAppUserDeleteCommand: ICommandFunc<string, OperationResponse<AppUserDeleteCommandOutputDTO>>
    {
    }
}