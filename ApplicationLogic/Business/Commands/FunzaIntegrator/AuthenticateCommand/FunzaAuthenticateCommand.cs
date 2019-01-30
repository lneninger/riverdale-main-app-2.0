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

        public OperationResponse<TokenSettings> Execute(FunzaAuthenticationSettings settings)
        {
            var result = new OperationResponse<TokenSettings>();

            var authenticateResult = this.Repository.Authenticate(settings.AuthenticationURL, settings.AuthenticationUserName, settings.AuthenticationPassword);
            result.AddResponse(authenticateResult);
            if (result.IsSucceed && authenticateResult.Bag != null)
            {
                FunzaAuthenticateCommandOutputDTO tempDTO = null;
                try
                {
                    // Trying another authentication format
                    // Local hosting
                    tempDTO = new FunzaAuthenticateCommandOutputDTO
                    {
                        AccessToken = authenticateResult.Bag["access_token"].ToString(),
                        TokenType = authenticateResult.Bag["token_type"].ToString(),
                        ExpiresIn = authenticateResult.Bag["expires_in"].ToString(),
                        UserName = authenticateResult.Bag["userName"].ToString(),
                        Issued = authenticateResult.Bag[".issued"].ToString(),
                        Expires = authenticateResult.Bag[".expires"].ToString(),
                    };
                }
                catch (Exception ex)
                {
                    // Trying another authentication format
                    // AzureHost
                    tempDTO = new FunzaAuthenticateCommandOutputDTO
                    {
                        AccessToken = authenticateResult.Bag["accessToken"].ToString(),
                        EncryptedAccessToken = authenticateResult.Bag["encryptedAccessToken"].ToString(),
                        ExpiresIn = authenticateResult.Bag["expireInSeconds"].ToString(),
                        UserId = authenticateResult.Bag["userId"].ToString(),
                    };
                }

                result.Bag = new TokenSettings
                {
                    AccessToken = tempDTO.AccessToken,
                    TokenType = tempDTO.TokenType,
                    UserName = tempDTO.UserName,
                    Issued = tempDTO.Issued,
                };

                if (TimeSpan.TryParse(tempDTO.ExpiresIn, out TimeSpan tempExpiresIn))
                {
                    result.Bag.ExpiresIn = tempExpiresIn;
                }

                if (DateTime.TryParse(tempDTO.Expires, out DateTime tempExpires))
                {
                    result.Bag.Expires = tempExpires;
                }
                else if (result.Bag.ExpiresIn.HasValue)
                {
                    if (result.Bag.ExpiresIn.Value.TotalDays > 1)
                    {
                        result.Bag.Expires = DateTime.UtcNow.AddDays(1);
                    }
                    else
                    {
                        result.Bag.Expires = DateTime.UtcNow.AddSeconds(result.Bag.ExpiresIn.Value.TotalSeconds);
                    }
                }
            }


            return result;
        }

        private bool ValidateToken(TokenSettings tokenSettings)
        {
            if (string.IsNullOrWhiteSpace(tokenSettings.AccessToken))
            {
                return false;
            }

            if (tokenSettings.Expires == null || tokenSettings.Expires < DateTime.UtcNow.AddMinutes(-1))
            {
                return false;
            }

            return true;
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
