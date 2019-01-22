using ApplicationLogic.AppSettings;
using ApplicationLogic.Business.Commands.FunzaIntegrator.GetQuotesCommand.Models;
using ApplicationLogic.Repositories.Funza;
using Framework.Autofac;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.FunzaIntegrator.GetQuotesCommand
{
    public class FunzaGetQuotesCommand : BaseIoCDisposable, IFunzaGetQuotesCommand
    {
        public FunzaGetQuotesCommand(IMastersRepository repository, FunzaSettings funzaSettings)
        {
            this.Repository = repository;
            this.FunzaSettings = funzaSettings;
        }

        public IMastersRepository Repository { get; }
        public FunzaSettings FunzaSettings { get; }

        public OperationResponse<IEnumerable<FunzaGetQuotesCommandOutputDTO>> Execute()
        {
            var result = new OperationResponse<IEnumerable<FunzaGetQuotesCommandOutputDTO>>();
                var requestResult = this.Repository.GetQuotes(this.FunzaSettings.GetQuotesURL, this.FunzaSettings.TokenSettings.AccessToken);
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
