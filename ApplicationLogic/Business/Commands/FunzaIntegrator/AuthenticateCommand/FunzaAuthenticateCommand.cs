﻿using System;
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
                if (result.IsSucceed)
                {
                    var tempDTO = new FunzaAuthenticateCommandOutputDTO
                    {
                        AccessToken = authenticateResult.Bag["access_token"].ToString(),
                        TokenType = authenticateResult.Bag["token_type"].ToString(),
                        ExpiresIn = authenticateResult.Bag["expires_in"].ToString(),
                        UserName = authenticateResult.Bag["userName"].ToString(),
                        Issued = authenticateResult.Bag[".issued"].ToString(),
                        Expires = authenticateResult.Bag[".expires"].ToString(),
                    };

                    result.Bag = new TokenSettings
                    {
                        AccessToken = result.Bag.AccessToken,
                        TokenType = result.Bag.TokenType,
                        UserName = result.Bag.UserName,
                        Issued = result.Bag.Issued,
                    };

                    if(TimeSpan.TryParse(authenticateResult.Bag["expires_in"].ToString(), out TimeSpan tempExpiresIn))
                    {
                    result.Bag.ExpiresIn = tempExpiresIn;
                    }

                    if(DateTime.TryParse(authenticateResult.Bag[".expires"].ToString(), out DateTime tempExpires))
                    {
                    result.Bag.Expires = tempExpires;
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
