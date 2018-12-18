using ApplicationLogic.Business.Commands.ProductMedia.InsertCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductMedia.InsertCommand
{
    public interface IProductMediaInsertCommand: ICommandFunc<ProductMediaInsertCommandInputDTO, OperationResponse<ProductMediaInsertCommandOutputDTO>>
    {
    }
}