using ApplicationLogic.Business.Commands.FunzaIntegrator.AuthenticateCommand.Models;
using ApplicationLogic.Business.Commands.FunzaIntegrator.GetProductsCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Repositories.Funza
{
    public interface ISecurityRepository
    {
        OperationResponse<Dictionary<string, object>> Authenticate(string authenticationURL, string authenticationUserName, string authenticationPassword);
    }
}
