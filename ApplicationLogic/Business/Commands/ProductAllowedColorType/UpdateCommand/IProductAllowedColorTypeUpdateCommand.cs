using ApplicationLogic.Business.Commands.ProductAllowedColorType.UpdateCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductAllowedColorType.UpdateCommand
{
    public interface IProductAllowedColorTypeUpdateCommand: ICommandFunc<ProductAllowedColorTypeUpdateCommandInputDTO, OperationResponse<ProductAllowedColorTypeUpdateCommandOutputDTO>>
    {
    }
}