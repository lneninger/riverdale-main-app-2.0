using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.DeleteCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.DeleteCommand
{
    public interface IProductCategoryAllowedSizeDeleteCommand : ICommandFunc<int, OperationResponse<ProductCategoryAllowedSizeDeleteCommandOutputDTO>>
    {
    }
}