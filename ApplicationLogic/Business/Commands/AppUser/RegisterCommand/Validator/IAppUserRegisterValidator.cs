﻿using ApplicationLogic.Business.Commands.AppUser.RegisterCommand.Models;
using ApplicationLogic.Business.Commons.Validators;
using Framework.Storage.DataHolders.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.AppUser.RegisterCommand
{
    public interface IAppUserRegisterValidator: IValidator<AppUserRegisterCommandInputDTO>
    {
    }
}