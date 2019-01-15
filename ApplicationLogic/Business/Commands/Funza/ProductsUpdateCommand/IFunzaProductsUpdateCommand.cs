using ApplicationLogic.Business.Commands.Funza.ProductsUpdateCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Funza.ProductsUpdateCommand.Models
{
    public interface IFunzaProductsUpdateCommand: ICommandFunc<IEnumerable<FunzaProductsUpdateCommandInputDTO>, OperationResponse<FunzaProductsUpdateCommandOutputDTO>>
    {
    }
}