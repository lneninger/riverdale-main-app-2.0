using Framework.Autofac;
using Framework.Commands;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Refit;
using FunzaApplicationLogic.Commands.FunzaIntegrators.GetColorsCommand.Models;
using FunzaApplicationLogic.Repositories.DB;
using FunzaDirectClients.Clients.Commons;
using FunzaDirectClients.Clients.ProductColor;
using FunzaDirectClients.Clients.ProductColor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunzaApplicationLogic.Commands.FunzaIntegrators.GetColorsCommand
{
    public class FunzaGetColorsCommand : BaseIoCDisposable, IFunzaGetColorsCommand
    {
        public FunzaGetColorsCommand(BaseRefitProxy<IProductColorClient> colorClient)
        {
            this.ProductColorClient = colorClient.Create();
        }

        public IProductColorClient ProductColorClient { get; }

        public async Task<OperationResponse<IEnumerable<DirectGetProductColorsResult>>> ExecuteAsync(PageQuery<FunzaGetColorsCommandInput> model)
        {
            try
            {
                var result = new OperationResponse<IEnumerable<DirectGetProductColorsResult>>();

                var funzaResponse = await this.ProductColorClient.GetProductColors();
                var funzaResult = funzaResponse.Content;

                result.Bag = funzaResult.Result.AsEnumerable();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
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
