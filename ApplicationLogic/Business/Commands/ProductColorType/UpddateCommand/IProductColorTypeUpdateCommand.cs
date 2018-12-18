using ApplicationLogic.Business.Commands.ProductColorType.UpdateCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductColorType.UpdateCommand
{
    public interface IProductColorTypeUpdateCommand: ICommandFunc<ProductColorTypeUpdateCommandInputDTO, OperationResponse<ProductColorTypeUpdateCommandOutputDTO>>
    {
    }
}