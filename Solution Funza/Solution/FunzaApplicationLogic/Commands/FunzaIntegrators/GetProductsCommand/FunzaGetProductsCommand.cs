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
using System.Linq;
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

        public async Task<OperationResponse<IEnumerable<FunzaGetProductsCommandOutput>>> ExecuteAsync(PageQuery<FunzaGetProductsCommandInput> model)
        {
            try
            {
                var result = new OperationResponse<IEnumerable<FunzaGetProductsCommandOutput>>();

                var funzaResponse = await this.ProductClient.GetProducts();
                var funzaResult = funzaResponse.Content;

                if (result.IsSucceed)
                {
                    result.Bag = funzaResult.Result.Select(funzaItem => new FunzaGetProductsCommandOutput
                    {
                        ProductId = funzaItem.IdProducto,
                        ReferenceId = funzaItem.IdReferencia,
                        ProductTypeId = funzaItem.IdTipoProducto,
                        ReferenceTypeId = funzaItem.IdTipoReferencia,
                        CategoryId = funzaItem.IdCategoria,
                        SpecieId = funzaItem.IdEspecie,
                        GradeId = funzaItem.IdGrado,
                        SendToQuotator = funzaItem.EnviarACotizador,
                        Active = funzaItem.Activo,
                        Category = funzaItem.Categoria,
                        Code = funzaItem.Codigo,
                        ReferenceCode = funzaItem.CodReferencia,
                        Description = funzaItem.Descripcion,
                        ReferenceDescription = funzaItem.DescripcionRef,
                        VarietyId = funzaItem.IdVariedad,
                        Comments = funzaItem.Observaciones,
                        ProductTypeName = funzaItem.TipoProducto,
                        ReferenceTypeName = funzaItem.TipoReferencia,
                        UpdatedDate = funzaItem.Updateddate,
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
