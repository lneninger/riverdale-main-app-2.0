using Framework.Autofac;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using FunzaApplicationLogic.Commands.FunzaIntegrators.GetSizesCommand.Models;
using FunzaApplicationLogic.Repositories.DB;
using FunzaDirectClients.Clients.Commons;
using FunzaDirectClients.Clients.Sizes;
using FunzaDirectClients.Clients.Sizes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunzaApplicationLogic.Commands.FunzaIntegrators.GetSizesCommand
{
    public class FunzaGetSizesCommand : BaseIoCDisposable, IFunzaGetSizesCommand
    {
        public FunzaGetSizesCommand(ISizeClient productCategoryClient)
        {
            this.SizeClient = productCategoryClient;
        }

        public ISizeClient SizeClient { get; }

        public async Task<OperationResponse<IEnumerable<FunzaGetSizesCommandOutput>>> ExecuteAsync(PageQuery<FunzaGetSizesCommandInput> model)
        {
            var result = new OperationResponse<IEnumerable<FunzaGetSizesCommandOutput>>();
            var funzaResponse = await this.SizeClient.GetSizes();
            var funzaResult = funzaResponse.Content;
            if (result.IsSucceed)
            {
                result.Bag = funzaResult.Result.Items.Select(funzaItem => new FunzaGetSizesCommandOutput
                {
                    Id = funzaItem.Id,
                    AllowCouse = funzaItem.AdmiteCausa,
                    AdmiteValidacion = funzaItem.AdmiteValidacion,
                    Description = funzaItem.Descripcion,
                    State = funzaItem.Estado,
                    Exportable = funzaItem.Exportable,
                    GradeId = funzaItem.IdGrado,
                    Name = funzaItem.Nombre,
                    EnglishName = funzaItem.NombreIngles,
                    Order = funzaItem.Orden,
                    Version = funzaItem.Version,
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
