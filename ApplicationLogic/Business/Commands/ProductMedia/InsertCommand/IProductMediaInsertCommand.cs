using ApplicationLogic.Business.Commands.ProductMedia.InsertCommand.Models;
using Framework.Storage.DataHolders.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductMedia.InsertCommand
{
    public interface IProductMediaInsertCommand: ICommandFunc<ProductMediaInsertCommandInputDTO, OperationResponse<ProductMediaInsertCommandOutputDTO>>
    {
    }
}