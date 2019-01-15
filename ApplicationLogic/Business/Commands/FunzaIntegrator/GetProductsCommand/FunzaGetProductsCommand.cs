using ApplicationLogic.AppSettings;
using ApplicationLogic.Business.Commands.FunzaIntegrator.GetProductsCommand.Models;
using ApplicationLogic.Repositories.Funza;
using Framework.Autofac;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.FunzaIntegrator.GetProductsCommand
{
    public class FunzaGetProductsCommand : BaseIoCDisposable, IFunzaGetProductsCommand
    {
        public FunzaGetProductsCommand(IMastersRepository repository, FunzaSettings funzaSettings)
        {
            this.Repository = repository;
            this.FunzaSettings = funzaSettings;
        }

        public IMastersRepository Repository { get; }
        public FunzaSettings FunzaSettings { get; }

        public OperationResponse<IEnumerable<FunzaGetProductsCommandOutputDTO>> Execute()
        {
            var result = new OperationResponse<IEnumerable<FunzaGetProductsCommandOutputDTO>>();
                var getProductsResult = this.Repository.GetProducts(this.FunzaSettings.GetProductsURL, this.FunzaSettings.TokenSettings.AccessToken);
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
