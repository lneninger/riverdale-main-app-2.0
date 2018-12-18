using ApplicationLogic.Business.Commands.Product.DeleteCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Product.DeleteCommand
{
    public interface IProductDeleteCommand: ICommandFunc<int, OperationResponse<ProductDeleteCommandOutputDTO>>
    {
    }
}