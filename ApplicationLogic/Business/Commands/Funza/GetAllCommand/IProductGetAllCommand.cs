using ApplicationLogic.Business.Commands.Funza.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Funza.GetAllCommand
{
    public interface IProductGetAllCommand: ICommandAction<OperationResponse<IEnumerable<ProductGetAllCommandOutputDTO>>>
    {
    }
}