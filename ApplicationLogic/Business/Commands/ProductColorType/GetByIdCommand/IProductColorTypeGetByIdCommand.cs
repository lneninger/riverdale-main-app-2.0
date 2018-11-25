using ApplicationLogic.Business.Commands.ProductColorType.GetByIdCommand.Models;
using System;

namespace ApplicationLogic.Business.Commands.ProductColorType.GetByIdCommand
{
    public interface IProductColorTypeGetByIdCommand: ICommandFunc<string, ProductColorTypeGetByIdCommandOutputDTO>
    {
    }
}