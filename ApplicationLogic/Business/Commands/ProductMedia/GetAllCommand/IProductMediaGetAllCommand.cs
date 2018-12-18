using ApplicationLogic.Business.Commands.ProductMedia.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductMedia.GetAllCommand
{
    public interface IProductMediaGetAllCommand: ICommandAction<OperationResponse<IEnumerable<ProductMediaGetAllCommandOutputDTO>>>
    {
    }
}