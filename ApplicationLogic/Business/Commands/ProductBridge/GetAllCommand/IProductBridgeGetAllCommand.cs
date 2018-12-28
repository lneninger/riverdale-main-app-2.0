using ApplicationLogic.Business.Commands.ProductBridge.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductBridge.GetAllCommand
{
    public interface IProductBridgeGetAllCommand : ICommandAction<OperationResponse<IEnumerable<ProductBridgeGetAllCommandOutputDTO>>>
    {
    }
}