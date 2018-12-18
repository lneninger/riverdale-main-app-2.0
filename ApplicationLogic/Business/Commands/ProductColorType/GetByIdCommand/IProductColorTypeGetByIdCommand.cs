using ApplicationLogic.Business.Commands.ProductColorType.GetByIdCommand.Models;
using Framework.Core.Messages;
using System;

namespace ApplicationLogic.Business.Commands.ProductColorType.GetByIdCommand
{
    public interface IProductColorTypeGetByIdCommand: ICommandFunc<string, OperationResponse<ProductColorTypeGetByIdCommandOutputDTO>>
    {
    }
}