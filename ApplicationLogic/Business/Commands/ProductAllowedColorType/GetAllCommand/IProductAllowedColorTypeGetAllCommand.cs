using ApplicationLogic.Business.Commands.ProductAllowedColorType.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductAllowedColorType.GetAllCommand
{
    public interface IProductAllowedColorTypeGetAllCommand: ICommandAction<OperationResponse<IEnumerable<ProductAllowedColorTypeGetAllCommandOutputDTO>>>
    {
    }
}