using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.InsertCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.InsertCommand
{
    public interface IProductCategoryAllowedSizeInsertCommand: ICommandFunc<ProductCategoryAllowedSizeInsertCommandInputDTO, OperationResponse<ProductCategoryAllowedSizeInsertCommandOutputDTO>>
    {
    }
}