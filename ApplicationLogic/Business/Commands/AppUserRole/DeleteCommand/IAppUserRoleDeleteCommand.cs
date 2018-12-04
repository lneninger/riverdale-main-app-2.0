﻿using ApplicationLogic.Business.Commands.AppUserRole.DeleteCommand.Models;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.AppUserRole.DeleteCommand
{
    public interface IAppUserRoleDeleteCommand: ICommandFunc<string, AppUserRoleDeleteCommandOutputDTO>
    {
    }
}