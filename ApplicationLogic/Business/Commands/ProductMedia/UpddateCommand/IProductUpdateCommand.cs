using ApplicationLogic.Business.Commands.ProductMedia.UpdateCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductMedia.UpdateCommand
{
    public interface IProductMediaUpdateCommand: ICommandFunc<ProductMediaUpdateCommandInputDTO, OperationResponse<ProductMediaUpdateCommandOutputDTO>>
    {
    }
}