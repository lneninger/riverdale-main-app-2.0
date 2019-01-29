using ApplicationLogic.AppSettings;
using ApplicationLogic.Business.Commands.FunzaIntegrator.GetProductsCommand.Models;
using ApplicationLogic.Business.Commons.FunzaManager;
using ApplicationLogic.Repositories.Funza;
using Framework.Autofac;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.FunzaIntegrator.GetProductsCommand
{
    public class FunzaGetProductsCommand : BaseIoCDisposable, IFunzaGetProductsCommand
    {
        public FunzaGetProductsCommand(IMastersRepository repository, IFunzaManager funzaManager)
        {
            this.Repository = repository;
            this.FunzaManager = funzaManager;
        }

        public IMastersRepository Repository { get; }
        public IFunzaManager FunzaManager { get; }

        public OperationResponse<IEnumerable<FunzaGetProductsCommandOutputDTO>> Execute()
        {
            var result = new OperationResponse<IEnumerable<FunzaGetProductsCommandOutputDTO>>();
            var authenticationSettings = this.FunzaManager.GetAuthenticationSetting("basic");
                var getProductsResult = this.Repository.GetProducts(this.FunzaManager.FunzaSettings.GetProductsURL, authenticationSettings.TokenSettings.AccessToken);
                result.AddResponse(getProductsResult);
                if (result.IsSucceed)
                {
                result.Bag = getProductsResult.Bag;
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
