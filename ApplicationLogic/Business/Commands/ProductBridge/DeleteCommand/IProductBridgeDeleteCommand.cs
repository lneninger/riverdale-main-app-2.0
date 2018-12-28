using ApplicationLogic.Business.Commands.ProductBridge.DeleteCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductBridge.DeleteCommand
{
    public interface IProductBridgeDeleteCommand : ICommandFunc<int, OperationResponse<ProductBridgeDeleteCommandOutputDTO>>
    {
    }
}