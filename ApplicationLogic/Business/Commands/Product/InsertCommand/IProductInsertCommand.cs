using ApplicationLogic.Business.Commands.Product.InsertCommand.Models;
using Framework.Storage.DataHolders.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Product.InsertCommand
{
    public interface IProductInsertCommand: ICommandFunc<ProductInsertCommandInputDTO, OperationResponse<ProductInsertCommandOutputDTO>>
    {
    }
}