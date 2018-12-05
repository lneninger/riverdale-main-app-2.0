using ApplicationLogic.Business.Commands.ProductColorType.InsertCommand.Models;
using Framework.Storage.DataHolders.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductColorType.InsertCommand
{
    public interface IProductColorTypeInsertCommand: ICommandFunc<ProductColorTypeInsertCommandInputDTO, OperationResponse<ProductColorTypeInsertCommandOutputDTO>>
    {
    }
}