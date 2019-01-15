using ApplicationLogic.Business.Commands.Funza.GetByIdCommand.Models;
using Framework.Core.Messages;
using System;

namespace ApplicationLogic.Business.Commands.Funza.GetByIdCommand
{
    public interface IProductGetByIdCommand: ICommandFunc<int, OperationResponse<ProductGetByIdCommandOutputDTO>>
    {
    }
}