using FunzaApplicationLogic.Commands.Funza.ProductsUpdateCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;
using Framework.Commands;
using FunzaApplicationLogic.Commands.Business.SyncCommand.Models;

namespace FunzaApplicationLogic.Commands.Funza.ProductsUpdateCommand.Models
{
    public interface IFunzaProductsUpdateCommand: ICommandFunc<SyncCommandEntityWrapperInput<ProductsUpdateCommandInput>, OperationResponse<ProductsUpdateCommandOutput>>
    {
    }
}