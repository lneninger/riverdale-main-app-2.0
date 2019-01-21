using ApplicationLogic.AppSettings;
using ApplicationLogic.Business.Commands.FunzaIntegrator.GetColorsCommand.Models;
using ApplicationLogic.Repositories.Funza;
using Framework.Autofac;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.FunzaIntegrator.GetColorsCommand
{
    public class FunzaGetColorsCommand : BaseIoCDisposable, IFunzaGetColorsCommand
    {
        public FunzaGetColorsCommand(IMastersRepository repository, FunzaSettings funzaSettings)
        {
            this.Repository = repository;
            this.FunzaSettings = funzaSettings;
        }

        public IMastersRepository Repository { get; }
        public FunzaSettings FunzaSettings { get; }

        public OperationResponse<IEnumerable<FunzaGetColorsCommandOutputDTO>> Execute()
        {
            var result = new OperationResponse<IEnumerable<FunzaGetColorsCommandOutputDTO>>();
                var getColorsResult = this.Repository.GetColors(this.FunzaSettings.GetColorsURL, this.FunzaSettings.TokenSettings.AccessToken);
                result.AddResponse(getColorsResult);
                if (result.IsSucceed)
                {
                result.Bag = getColorsResult.Bag;
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
