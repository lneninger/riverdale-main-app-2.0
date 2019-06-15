using ApplicationLogic.AppSettings;
using FunzaApplicationLogic.Commands.FunzaIntegrators.GetPackingsCommand.Models;
using ApplicationLogic.Business.Commons.FunzaManager;
using ApplicationLogic.Repositories.Funza;
using Framework.Autofac;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace FunzaApplicationLogic.Commands.FunzaIntegrators.GetPackingsCommand
{
    public class FunzaGetPackingsCommand : BaseIoCDisposable, IFunzaGetPackingsCommand
    {
        public FunzaGetPackingsCommand(IMastersRepository repository, IFunzaManager funzaManager)
        {
            this.Repository = repository;
            this.FunzaManager = funzaManager;
        }

        public IMastersRepository Repository { get; }
        public IFunzaManager FunzaManager { get; }

        public OperationResponse<IEnumerable<FunzaGetPackingsCommandOutputDTO>> Execute()
        {
            var result = new OperationResponse<IEnumerable<FunzaGetPackingsCommandOutputDTO>>();
            var authenticationSettings = this.FunzaManager.GetAuthenticationSetting("basic");
                var getPackingsResult = this.Repository.GetPackings(this.FunzaManager.FunzaSettings.GetPackingsURL, authenticationSettings.TokenSettings.AccessToken);
                result.AddResponse(getPackingsResult);
                if (result.IsSucceed)
                {
                result.Bag = getPackingsResult.Bag;
                }

            return result;
        }

        protected override void Dispose(bool disposing)
        {
            //ReleaseBuffer(buffer); // release unmanaged memory  
            if (disposing)
            { // release other disposable objects  
                IoCGlobal.MarkInstanceForDisposal(this);
            }
        }
    }
}
