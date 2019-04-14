using ApplicationLogic.Business.Commands.ProductCategory.DeleteCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductCategory.DeleteCommand
{
    public interface IProductCategoryDeleteCommand : ICommandFunc<int, OperationResponse<ProductCategoryDeleteCommandOutputDTO>>
    {
    }
}