using ApplicationLogic.AppSettings;
using ApplicationLogic.Business.Commands.FunzaIntegrator.GetCategoriesCommand.Models;
using ApplicationLogic.Repositories.Funza;
using Framework.Autofac;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.FunzaIntegrator.GetCategoriesCommand
{
    public class FunzaGetCategoriesCommand : BaseIoCDisposable, IFunzaGetCategoriesCommand
    {
        public FunzaGetCategoriesCommand(IMastersRepository repository, FunzaSettings funzaSettings)
        {
            this.Repository = repository;
            this.FunzaSettings = funzaSettings;
        }

        public IMastersRepository Repository { get; }
        public FunzaSettings FunzaSettings { get; }

        public OperationResponse<IEnumerable<FunzaGetCategoriesCommandOutputDTO>> Execute()
        {
            var result = new OperationResponse<IEnumerable<FunzaGetCategoriesCommandOutputDTO>>();
                var getCategoriesResult = this.Repository.GetCategories(this.FunzaSettings.GetProductsURL, this.FunzaSettings.TokenSettings.AccessToken);
                result.AddResponse(getCategoriesResult);
                if (result.IsSucceed)
                {
                result.Bag = getCategoriesResult.Bag;
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
