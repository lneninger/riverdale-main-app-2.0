using ApplicationLogic.AppSettings;
using ApplicationLogic.Business.Commands.FunzaIntegrator.AuthenticateCommand;
using ApplicationLogic.Business.Commands.FunzaIntegrator.AuthenticateFullCommand;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commons.FunzaManager
{
    public class FunzaManager : IFunzaManager
    {
        public FunzaManager(FunzaSettings funzaSettings, FunzaAuthenticateCommand funzaAuthenticateCommand)
        {
            this.FunzaSettings = funzaSettings;
            this.FunzaAuthenticateCommand = funzaAuthenticateCommand;
        }

        public FunzaSettings FunzaSettings { get; }
        public FunzaAuthenticateCommand FunzaAuthenticateCommand { get; }

        public FunzaAuthenticationSettings GetAuthenticationSetting(string key)
        {
            return this.FunzaSettings.AuthenticationSettingsCollection[key];
        }

        public OperationResponse RefreshAuthentication(FunzaAuthenticationSettings settings)
        {
            var result = new OperationResponse();
            if (!this.ValidAuthenticationToken(settings))
            {
                var authenticationResult = this.FunzaAuthenticateCommand.Execute(settings);
                result.AddResponse(authenticationResult);
                if (result.IsSucceed)
                {
                    settings.TokenSettings = authenticationResult.Bag;
                }
            }

            return result;
        }

        private bool ValidAuthenticationToken(FunzaAuthenticationSettings settings)
        {
            if (settings.TokenSettings == null)
            {
                return false;
            }

            var expirationDate = settings.TokenSettings.Expires;
            if (expirationDate > DateTime.Now.AddHours(-3))
            {
                return false;
            }



            return true;
        }
    }
}
