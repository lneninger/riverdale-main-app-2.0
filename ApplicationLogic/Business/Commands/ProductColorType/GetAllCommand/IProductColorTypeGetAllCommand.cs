using ApplicationLogic.Business.Commands.ProductColorType.GetAllCommand.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductColorType.GetAllCommand
{
    public interface IProductColorTypeGetAllCommand: ICommandAction<IEnumerable<ProductColorTypeGetAllCommandOutputDTO>>
    {
    }
}