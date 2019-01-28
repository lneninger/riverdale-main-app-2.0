using ApplicationLogic.AppSettings;
using ApplicationLogic.Business.Commands.FunzaIntegrator.GetQuotesCommand.Models;
using ApplicationLogic.Business.Commons.FunzaManager;
using ApplicationLogic.Repositories.Funza;
using Framework.Autofac;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.FunzaIntegrator.GetQuotesCommand
{
    public class FunzaGetQuotesCommand : BaseIoCDisposable, IFunzaGetQuotesCommand
    {
        public FunzaGetQuotesCommand(IMastersRepository repository, IFunzaManager funzaManager)
        {
            this.Repository = repository;
            this.FunzaManager = funzaManager;
        }

        public IMastersRepository Repository { get; }
        public IFunzaManager FunzaManager { get; }

        public OperationResponse<IEnumerable<FunzaGetQuotesCommandOutputDTO>> Execute()
        {
            var result = new OperationResponse<IEnumerable<FunzaGetQuotesCommandOutputDTO>>();
            var settings = this.FunzaManager.GetAuthenticationSetting("basic");
            var refreshAuthenticationResult = this.FunzaManager.RefreshAuthentication(settings);

            result.AddResponse(refreshAuthenticationResult);
            if (!result.IsSucceed)
            {
                return result;
            }

                var requestResult = this.Repository.GetQuotes(this.FunzaManager.FunzaSettings.GetQuotesURL, settings.TokenSettings.AccessToken);
                result.AddResponse(requestResult);
                if (result.IsSucceed)
                {
                result.Bag = requestResult.Bag;
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
