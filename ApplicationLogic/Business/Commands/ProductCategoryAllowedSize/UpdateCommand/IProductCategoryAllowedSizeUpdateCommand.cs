using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.UpdateCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.UpdateCommand
{
    public interface IProductCategoryAllowedSizeUpdateCommand: ICommandFunc<ProductCategoryAllowedSizeUpdateCommandInputDTO, OperationResponse<ProductCategoryAllowedSizeUpdateCommandOutputDTO>>
    {
    }
}