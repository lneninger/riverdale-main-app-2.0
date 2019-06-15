using Framework.Autofac;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using FunzaApplicationLogic.Commands.FunzaIntegrators.GetProductsCommand.Models;
using FunzaApplicationLogic.Repositories.DB;
using FunzaDirectClients.Clients.Commons;
using FunzaDirectClients.Clients.Product;
using FunzaDirectClients.InternalClients.Product.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunzaApplicationLogic.Commands.FunzaIntegrators.GetProductsCommand
{
    public class FunzaGetProductsCommand : BaseIoCDisposable, IFunzaGetProductsCommand
    {
        public FunzaGetProductsCommand(IProductClient productClient)
        {
            this.ProductClient = productClient;
        }

        public IProductClient ProductClient { get; }

        public async Task<OperationResponse<PageResult<FunzaGetProductsCommandOutput>>> ExecuteAsync(PageQuery<FunzaGetProductsCommandInput> model)
        {
            var result = new OperationResponse<PageResult<FunzaGetProductsCommandOutput>>();

            var funzaResponse = await this.ProductClient.GetProducts();
            var funzaResult = funzaResponse.Content;

            if (result.IsSucceed)
            {
                result.Bag = funzaResult.Result.ToPageResult<FunzaDirectGetProductsResult, FunzaGetProductsCommandOutput>(funzaItem => new FunzaGetProductsCommandOutput {


                } );
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
