using FunzaApplicationLogic.Commands.Funza.ProductsUpdateCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;
using Framework.Commands;

namespace FunzaApplicationLogic.Commands.Funza.ProductsUpdateCommand.Models
{
    public interface IFunzaProductsUpdateCommand: ICommandFunc<IEnumerable<ProductsUpdateCommandInput>, OperationResponse<ProductsUpdateCommandOutput>>
    {
    }
}