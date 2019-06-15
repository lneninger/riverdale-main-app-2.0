using FunzaApplicationLogic.Commands.Funza.GetByIdCommand.Models;
using Framework.Core.Messages;
using System;

namespace FunzaApplicationLogic.Commands.Funza.GetByIdCommand
{
    public interface IProductGetByIdCommand: ICommandFunc<int, OperationResponse<ProductGetByIdCommandOutputDTO>>
    {
    }
}