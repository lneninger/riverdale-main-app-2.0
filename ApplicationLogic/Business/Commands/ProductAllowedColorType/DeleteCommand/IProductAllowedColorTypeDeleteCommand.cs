using ApplicationLogic.Business.Commands.ProductAllowedColorType.DeleteCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductAllowedColorType.DeleteCommand
{
    public interface IProductAllowedColorTypeDeleteCommand : ICommandFunc<int, OperationResponse<ProductAllowedColorTypeDeleteCommandOutputDTO>>
    {
    }
}