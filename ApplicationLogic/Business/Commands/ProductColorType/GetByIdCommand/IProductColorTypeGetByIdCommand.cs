using ApplicationLogic.Business.Commands.ProductColorType.GetByIdCommand.Models;
using Framework.Storage.DataHolders.Messages;
using System;

namespace ApplicationLogic.Business.Commands.ProductColorType.GetByIdCommand
{
    public interface IProductColorTypeGetByIdCommand: ICommandFunc<string, OperationResponse<ProductColorTypeGetByIdCommandOutputDTO>>
    {
    }
}