using ApplicationLogic.Business.Commands.ProductColorType.DeleteCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductColorType.DeleteCommand
{
    public interface IProductColorTypeDeleteCommand: ICommandFunc<string, OperationResponse<ProductColorTypeDeleteCommandOutputDTO>>
    {
    }
}