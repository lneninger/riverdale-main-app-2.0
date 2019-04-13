using ApplicationLogic.Business.Commands.ProductCategory.UpdateCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductCategory.UpdateCommand
{
    public interface IProductCategoryUpdateCommand: ICommandFunc<ProductCategoryUpdateCommandInputDTO, OperationResponse<ProductCategoryUpdateCommandOutputDTO>>
    {
    }
}