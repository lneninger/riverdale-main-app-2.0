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
using ApplicationLogic.Business.Commands.Funza.AuthenticateCommand.Models;
using ApplicationLogic.AppSettings;

namespace ApplicationLogic.Business.Commands.Funza.AuthenticateCommand
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
                var getByIdResult = this.Repository.Authenticate(this.FunzaSettings.AuthenticationURL, this.FunzaSettings.AuthenticationUserName, this.FunzaSettings.AuthenticationPassword);
                result.AddResponse(getByIdResult);
                if (result.IsSucceed)
                {
                    result.Bag = new FunzaAuthenticateCommandOutputDTO
                    {
                        AccessToken = getByIdResult.Bag["access_token"].ToString(),
                        TokenType = getByIdResult.Bag["token_type"].ToString(),
                        ExpiresIn = getByIdResult.Bag["expires_in"].ToString(),
                        UserName = getByIdResult.Bag["userName"].ToString(),
                        Issued = getByIdResult.Bag[".issued"].ToString(),
                        Expires = getByIdResult.Bag[".expires"].ToString(),
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
