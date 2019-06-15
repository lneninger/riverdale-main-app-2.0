using FunzaApplicationLogic.Commands.Funza.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace FunzaApplicationLogic.Commands.Funza.GetAllCommand
{
    public interface IProductGetAllCommand: ICommandAction<OperationResponse<IEnumerable<ProductGetAllCommandOutputDTO>>>
    {
    }
}