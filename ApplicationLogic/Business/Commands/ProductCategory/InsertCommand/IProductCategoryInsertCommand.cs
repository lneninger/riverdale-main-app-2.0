using ApplicationLogic.Business.Commands.ProductCategory.InsertCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductCategory.InsertCommand
{
    public interface IProductCategoryInsertCommand: ICommandFunc<ProductCategoryInsertCommandInputDTO, OperationResponse<ProductCategoryInsertCommandOutputDTO>>
    {
    }
}