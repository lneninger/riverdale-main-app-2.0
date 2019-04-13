using ApplicationLogic.Business.Commands.ProductCategory.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductCategory.GetAllCommand
{
    public interface IProductCategoryGetAllCommand : ICommandAction<OperationResponse<IEnumerable<ProductCategoryGetAllCommandOutputDTO>>>
    {
    }
}