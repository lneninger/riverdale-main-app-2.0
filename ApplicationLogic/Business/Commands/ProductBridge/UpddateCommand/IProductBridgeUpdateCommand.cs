using ApplicationLogic.Business.Commands.ProductBridge.UpdateCommand.Models;

using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductBridge.UpdateCommand
{
    public interface IProductBridgeUpdateCommand : ICommandFunc<ProductBridgeUpdateCommandInputDTO, OperationResponse<ProductBridgeUpdateCommandOutputDTO>>
    {
    }
}