using ApplicationLogic.Business.Commands.ProductColorType.GetAllCommand.Models;
using Framework.Storage.DataHolders.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductColorType.GetAllCommand
{
    public interface IProductColorTypeGetAllCommand: ICommandAction<OperationResponse<IEnumerable<ProductColorTypeGetAllCommandOutputDTO>>>
    {
    }
}