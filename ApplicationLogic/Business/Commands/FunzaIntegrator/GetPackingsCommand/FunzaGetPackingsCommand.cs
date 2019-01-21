using ApplicationLogic.AppSettings;
using ApplicationLogic.Business.Commands.FunzaIntegrator.GetPackingsCommand.Models;
using ApplicationLogic.Repositories.Funza;
using Framework.Autofac;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.FunzaIntegrator.GetPackingsCommand
{
    public class FunzaGetPackingsCommand : BaseIoCDisposable, IFunzaGetPackingsCommand
    {
        public FunzaGetPackingsCommand(IMastersRepository repository, FunzaSettings funzaSettings)
        {
            this.Repository = repository;
            this.FunzaSettings = funzaSettings;
        }

        public IMastersRepository Repository { get; }
        public FunzaSettings FunzaSettings { get; }

        public OperationResponse<IEnumerable<FunzaGetPackingsCommandOutputDTO>> Execute()
        {
            var result = new OperationResponse<IEnumerable<FunzaGetPackingsCommandOutputDTO>>();
                var getPackingsResult = this.Repository.GetPackings(this.FunzaSettings.GetProductsURL, this.FunzaSettings.TokenSettings.AccessToken);
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
