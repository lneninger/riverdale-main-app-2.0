using ApplicationLogic.Business.Commands.ProductBridge.InsertCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductBridge.InsertCommand
{
    public interface IProductBridgeInsertCommand : ICommandFunc<ProductBridgeInsertCommandInputDTO, OperationResponse<ProductBridgeInsertCommandOutputDTO>>
    {
    }
}