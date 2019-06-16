using Framework.Autofac;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using FunzaApplicationLogic.Commands.FunzaIntegrators.GetCategoriesCommand.Models;
using FunzaApplicationLogic.Repositories.DB;
using FunzaDirectClients.Clients.Commons;
using FunzaDirectClients.Clients.ProductCategory;
using FunzaDirectClients.Clients.ProductCategory.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunzaApplicationLogic.Commands.FunzaIntegrators.GetCategoriesCommand
{
    public class FunzaGetCategoriesCommand : BaseIoCDisposable, IFunzaGetCategoriesCommand
    {
        public FunzaGetCategoriesCommand(IProductCategoryClient productCategoryClient)
        {
            this.ProductCategoryClient = productCategoryClient;
        }

        public IProductCategoryClient ProductCategoryClient { get; }

        public async Task<OperationResponse<PageResult<FunzaGetCategoriesCommandOutput>>> ExecuteAsync(PageQuery<FunzaGetCategoriesCommandInput> model)
        {
            var result = new OperationResponse<PageResult<FunzaGetCategoriesCommandOutput>>();
            var funzaResponse = await this.ProductCategoryClient.GetProductCategories();
            var funzaResult = funzaResponse.Content;
            if (result.IsSucceed)
            {
                result.Bag = funzaResult.Result.ToPageResult<DirectGetProductCategoriesResult, FunzaGetCategoriesCommandOutput > (funzaItem => new FunzaGetCategoriesCommandOutput
                {
                });
            }

            return result;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            { // release other disposable objects  
                IoCGlobal.MarkInstanceForDisposal(this);
            }
        }
    }
}
