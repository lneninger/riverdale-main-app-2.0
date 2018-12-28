using ApplicationLogic.Business.Commands.ProductBridge.GetByIdCommand.Models;
using Framework.Core.Messages;
using System;

namespace ApplicationLogic.Business.Commands.ProductBridge.GetByIdCommand
{
    public interface IProductBridgeGetByIdCommand : ICommandFunc<int, OperationResponse<ProductBridgeGetByIdCommandOutputDTO>>
    {
    }
}