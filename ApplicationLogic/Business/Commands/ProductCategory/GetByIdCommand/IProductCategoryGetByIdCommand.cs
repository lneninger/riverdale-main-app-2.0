using ApplicationLogic.Business.Commands.ProductCategory.GetByIdCommand.Models;
using Framework.Core.Messages;
using System;

namespace ApplicationLogic.Business.Commands.ProductCategory.GetByIdCommand
{
    public interface IProductCategoryGetByIdCommand: ICommandFunc<string, OperationResponse<ProductCategoryGetByIdCommandOutputDTO>>
    {
    }
}