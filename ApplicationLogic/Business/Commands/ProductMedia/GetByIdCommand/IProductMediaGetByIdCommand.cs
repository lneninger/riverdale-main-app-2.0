using ApplicationLogic.Business.Commands.ProductMedia.GetByIdCommand.Models;
using Framework.Storage.DataHolders.Messages;
using System;

namespace ApplicationLogic.Business.Commands.ProductMedia.GetByIdCommand
{
    public interface IProductMediaGetByIdCommand: ICommandFunc<int, OperationResponse<ProductMediaGetByIdCommandOutputDTO>>
    {
    }
}