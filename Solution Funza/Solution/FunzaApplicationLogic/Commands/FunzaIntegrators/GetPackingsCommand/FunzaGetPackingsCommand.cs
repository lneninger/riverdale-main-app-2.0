using FunzaApplicationLogic.Commands.FunzaIntegrators.GetPackingsCommand.Models;
using Framework.Autofac;
using Framework.Core.Messages;
using System.Collections.Generic;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using FunzaDirectClients.Clients.Packing;
using FunzaDirectClients.Clients.Packing.Models;
using System.Threading.Tasks;
using FunzaDirectClients.Clients.Commons;

namespace FunzaApplicationLogic.Commands.FunzaIntegrators.GetPackingsCommand
{
    public class FunzaGetPackingsCommand : BaseIoCDisposable, IFunzaGetPackingsCommand
    {
        public FunzaGetPackingsCommand(/*IMastersRepository repository, */IPackingClient packingClient)
        {
            this.PackingClient = packingClient;
        }

        public IPackingClient PackingClient { get; }

        public async Task<OperationResponse<PageResult<GetPackingsCommandOutput>>> ExecuteAsync(PageQuery<GetPackingsCommandInput> model)
        {
            var result = new OperationResponse<PageResult<GetPackingsCommandOutput>>();
            var funzaResponse = await this.PackingClient.GetPackings();
            var funzaResult = funzaResponse.Content;

            if (result.IsSucceed)
            {
                result.Bag = funzaResult.Result.ToPageResult<DirectGetPackingsResult, GetPackingsCommandOutput>(funzaItem => new GetPackingsCommandOutput
                {
                });
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
