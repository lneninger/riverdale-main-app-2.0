using Framework.Autofac;
using Framework.Commands;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using FunzaApplicationLogic.Commands.FunzaIntegrators.GetColorsCommand.Models;
using FunzaApplicationLogic.Repositories.DB;
using FunzaDirectClients.Clients.Commons;
using FunzaDirectClients.Clients.ProductColor;
using FunzaDirectClients.Clients.ProductColor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunzaApplicationLogic.Commands.FunzaIntegrators.GetColorsCommand
{
    public class FunzaGetColorsCommand : BaseIoCDisposable, IFunzaGetColorsCommand
    {
        public FunzaGetColorsCommand(IProductColorClient colorClient)
        {
            this.ProductColorClient = colorClient;
        }

        public IProductColorClient ProductColorClient { get; }

        public async Task<OperationResponse<PageResult<FunzaGetColorsCommandOutput>>> ExecuteAsync(PageQuery<FunzaGetColorsCommandInput> model)
        {
            var result = new OperationResponse<PageResult<FunzaGetColorsCommandOutput>>();
            var funzaResponse = await this.ProductColorClient.GetProductColors();
            var funzaResult = funzaResponse.Content;

            if (result.IsSucceed)
            {
                result.Bag = funzaResult.Result.ToPageResult<DirectGetProductColorsResult, FunzaGetColorsCommandOutput>(funzaItem => new FunzaGetColorsCommandOutput
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

                //if (resource != null) resource.Dispose();
            }
        }

        Task<OperationResponse<IEnumerable<FunzaGetColorsCommandOutput>>> ICommandFuncAsync<PageQuery<FunzaGetColorsCommandInput>, OperationResponse<IEnumerable<FunzaGetColorsCommandOutput>>>.ExecuteAsync(PageQuery<FunzaGetColorsCommandInput> input)
        {
            throw new System.NotImplementedException();
        }
    }
}
