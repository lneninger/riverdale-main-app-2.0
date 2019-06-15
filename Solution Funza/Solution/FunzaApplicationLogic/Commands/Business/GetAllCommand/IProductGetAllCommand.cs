using FunzaApplicationLogic.Commands.Funza.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;
using Framework.Commands;

namespace FunzaApplicationLogic.Commands.Funza.GetAllCommand
{
    public interface IProductGetAllCommand: ICommandAction<OperationResponse<IEnumerable<ProductGetAllCommandOutput>>>
    {
    }
}