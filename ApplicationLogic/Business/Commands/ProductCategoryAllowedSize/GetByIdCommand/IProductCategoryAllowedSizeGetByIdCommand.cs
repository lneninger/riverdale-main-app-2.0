using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.GetByIdCommand.Models;
using Framework.Core.Messages;
using System;

namespace ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.GetByIdCommand
{
    public interface IProductCategoryAllowedSizeGetByIdCommand: ICommandFunc<int, OperationResponse<ProductCategoryAllowedSizeGetByIdCommandOutputDTO>>
    {
    }
}