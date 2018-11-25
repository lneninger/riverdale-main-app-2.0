using ApplicationLogic.Business.Commands.ProductColorType.DeleteCommand.Models;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductColorType.DeleteCommand
{
    public interface IProductColorTypeDeleteCommand: ICommandFunc<string, ProductColorTypeDeleteCommandOutputDTO>
    {
    }
}