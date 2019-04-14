using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.GetAllCommand
{
    public interface IProductCategoryAllowedSizeGetAllCommand: ICommandAction<OperationResponse<IEnumerable<ProductCategoryAllowedSizeGetAllCommandOutputDTO>>>
    {
    }
}