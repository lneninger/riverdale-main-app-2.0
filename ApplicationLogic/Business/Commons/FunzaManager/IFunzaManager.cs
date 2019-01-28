using ApplicationLogic.AppSettings;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commons.FunzaManager
{
    public interface IFunzaManager
    {
        FunzaSettings FunzaSettings { get; }

        FunzaAuthenticationSettings GetAuthenticationSetting(string key);

        OperationResponse RefreshAuthentication(FunzaAuthenticationSettings settings);
    }
}
