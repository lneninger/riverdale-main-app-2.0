using ApplicationLogic.Business.Commands.ProductColorType.UpdateCommand.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductColorType.UpdateCommand
{
    public interface IProductColorTypeUpdateCommand: ICommandFunc<ProductColorTypeUpdateCommandInputDTO, ProductColorTypeUpdateCommandOutputDTO>
    {
    }
}