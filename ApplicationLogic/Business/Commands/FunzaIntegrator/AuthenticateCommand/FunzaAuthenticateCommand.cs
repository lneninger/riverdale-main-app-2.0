using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Product.DeleteCommand.Models;
using Framework.Core.Messages;
using System.Linq;
using ApplicationLogic.Repositories.Funza;
using Framework.Autofac;
using ApplicationLogic.Business.Commands.FunzaIntegrator.AuthenticateCommand.Models;
using ApplicationLogic.AppSettings;

namespace ApplicationLogic.Business.Commands.FunzaIntegrator.AuthenticateCommand
{
    public class FunzaAuthenticateCommand : BaseIoCDisposable, IFunzaAuthenticateCommand
    {
        public FunzaAuthenticateCommand(Repositories.Funza.ISecurityRepository repository, FunzaSettings funzaSettings)
        {
            this.Repository = repository;
            this.FunzaSettings = funzaSettings;
        }

        public ISecurityRepository Repository { get; }
        public FunzaSettings FunzaSettings { get; }

        public OperationResponse<FunzaAuthenticateCommandOutputDTO> Execute()
        {
            var result = new OperationResponse<FunzaAuthenticateCommandOutputDTO>();
            var authenticateResult = this.Repository.Authenticate(this.FunzaSettings.AuthenticationURL, this.FunzaSettings.AuthenticationUserName, this.FunzaSettings.AuthenticationPassword);
            result.AddResponse(authenticateResult);
            if (result.IsSucceed)
            {
                result.Bag = new FunzaAuthenticateCommandOutputDTO
                {
                    AccessToken = authenticateResult.Bag["access_token"].ToString(),
                    TokenType = authenticateResult.Bag["token_type"].ToString(),
                    ExpiresIn = authenticateResult.Bag["expires_in"].ToString(),
                    UserName = authenticateResult.Bag["userName"].ToString(),
                    Issued = authenticateResult.Bag[".issued"].ToString(),
                    Expires = authenticateResult.Bag[".expires"].ToString(),
                };

                this.FunzaSettings.TokenSettings = new TokenSettings
                {
                    AccessToken = result.Bag.AccessToken,
                    TokenType = result.Bag.TokenType,
                    ExpiresIn = result.Bag.ExpiresIn,
                    UserName = result.Bag.UserName,
                    Issued = result.Bag.Issued,
                    Expires = result.Bag.Expires,
                };
            }

            return result;
        }

        protected override void Dispose(bool disposing)
        {
            //ReleaseBuffer(buffer); // release unmanaged memory  
            if (disposing)
            { // release other disposable objects  
                IoCGlobal.MarkInstanceForDisposal(this);

                //if (resource != null) resource.Dispose();
            }
        }
    }
}
