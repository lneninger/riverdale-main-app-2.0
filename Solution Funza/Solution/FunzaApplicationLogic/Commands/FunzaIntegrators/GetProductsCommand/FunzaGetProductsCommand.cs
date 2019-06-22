using Framework.Autofac;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Refit;
using FunzaApplicationLogic.Commands.FunzaIntegrators.GetProductsCommand.Models;
using FunzaApplicationLogic.Repositories.DB;
using FunzaDirectClients.Clients.Commons;
using FunzaDirectClients.Clients.Product;
using FunzaDirectClients.Clients.Product.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunzaApplicationLogic.Commands.FunzaIntegrators.GetProductsCommand
{
    public class FunzaGetProductsCommand : BaseIoCDisposable, IFunzaGetProductsCommand
    {
        public FunzaGetProductsCommand(BaseRefitProxy<IProductClient> productClient)
        {
            this.ProductClient = productClient.Create();
        }

        public IProductClient ProductClient { get; }

        public async Task<OperationResponse<PageResult<FunzaGetProductsCommandOutput>>> ExecuteAsync(PageQuery<FunzaGetProductsCommandInput> model)
        {
            try
            {
                var result = new OperationResponse<PageResult<FunzaGetProductsCommandOutput>>();

                var funzaResponse = await this.ProductClient.GetProducts();
                var funzaResult = funzaResponse.Content;

                if (result.IsSucceed)
                {
                    result.Bag = funzaResult.Result.ToPageResult<DirectGetProductsResult, FunzaGetProductsCommandOutput>(funzaItem => new FunzaGetProductsCommandOutput
                    {


                    });
                }

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

                //if (resource != null) resource.Dispose();
            }
        }
    }
}
