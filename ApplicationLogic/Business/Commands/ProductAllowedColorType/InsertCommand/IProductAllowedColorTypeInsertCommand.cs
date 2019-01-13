using ApplicationLogic.Business.Commands.ProductAllowedColorType.InsertCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductAllowedColorType.InsertCommand
{
    public interface IProductAllowedColorTypeInsertCommand: ICommandFunc<ProductAllowedColorTypeInsertCommandInputDTO, OperationResponse<ProductAllowedColorTypeInsertCommandOutputDTO>>
    {
    }
}