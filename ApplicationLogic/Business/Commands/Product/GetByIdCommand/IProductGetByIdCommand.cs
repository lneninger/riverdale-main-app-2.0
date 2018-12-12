using ApplicationLogic.Business.Commands.Product.GetByIdCommand.Models;
using Framework.Storage.DataHolders.Messages;
using System;

namespace ApplicationLogic.Business.Commands.Product.GetByIdCommand
{
    public interface IProductGetByIdCommand: ICommandFunc<int, OperationResponse<ProductGetByIdCommandOutputDTO>>
    {
    }
}