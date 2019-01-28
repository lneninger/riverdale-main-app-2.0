using ApplicationLogic.AppSettings;
using ApplicationLogic.Business.Commands.FunzaIntegrator.AuthenticateCommand.Models;
using ApplicationLogic.Business.Commands.Product.DeleteCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.FunzaIntegrator.AuthenticateCommand
{
    public interface IFunzaAuthenticateCommand: ICommandAction<OperationResponse<TokenSettings>>
    {
    }
}