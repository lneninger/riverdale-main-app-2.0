using FunzaApplicationLogic.Commands.FunzaIntegrators.GetPackingsCommand.Models;
using Framework.Autofac;
using Framework.Core.Messages;
using System.Collections.Generic;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using FunzaDirectClients.Clients.Packing;
using FunzaDirectClients.Clients.Packing.Models;
using System.Threading.Tasks;
using FunzaDirectClients.Clients.Commons;
using Framework.Refit;
using System.Linq;
using System;

namespace FunzaApplicationLogic.Commands.FunzaIntegrators.GetPackingsCommand
{
    public class FunzaGetPackingsCommand : BaseIoCDisposable, IFunzaGetPackingsCommand
    {
        public FunzaGetPackingsCommand(BaseRefitProxy<IPackingClient> packingClient)
        {
            this.PackingClient = packingClient.Create();
        }

        public IPackingClient PackingClient { get; }

        public async Task<OperationResponse<IEnumerable<DirectGetPackingsResult>>> ExecuteAsync(PageQuery<GetPackingsCommandInput> model)
        {
            try
            {
                var result = new OperationResponse<IEnumerable<DirectGetPackingsResult>>();
                var funzaResponse = await this.PackingClient.GetPackings();
                var funzaResult = funzaResponse.Content;

                result.Bag = funzaResult.Result.AsEnumerable();

                return result;
            }
            catch (Exception ex)
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
            }
        }
    }
}
