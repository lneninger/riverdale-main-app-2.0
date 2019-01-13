using ApplicationLogic.Business.Commands.ProductAllowedColorType.GetByIdCommand.Models;
using Framework.Core.Messages;
using System;

namespace ApplicationLogic.Business.Commands.ProductAllowedColorType.GetByIdCommand
{
    public interface IProductAllowedColorTypeGetByIdCommand: ICommandFunc<int, OperationResponse<ProductAllowedColorTypeGetByIdCommandOutputDTO>>
    {
    }
}