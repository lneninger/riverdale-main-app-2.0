using ApplicationLogic.Business.Commands.Funza.AuthenticateCommand.Models;
using ApplicationLogic.Business.Commands.Product.DeleteCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Funza.AuthenticateCommand
{
    public interface IFunzaAuthenticateCommand: ICommandAction<OperationResponse<FunzaAuthenticateCommandOutputDTO>>
    {
    }
}