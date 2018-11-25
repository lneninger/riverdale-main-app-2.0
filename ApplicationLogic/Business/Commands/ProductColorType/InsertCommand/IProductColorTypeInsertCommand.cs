using ApplicationLogic.Business.Commands.ProductColorType.InsertCommand.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductColorType.InsertCommand
{
    public interface IProductColorTypeInsertCommand: ICommandFunc<ProductColorTypeInsertCommandInputDTO, ProductColorTypeInsertCommandOutputDTO>
    {
    }
}