using ApplicationLogic.Business.Commands.ProductMedia.DeleteCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductMedia.DeleteCommand
{
    public interface IProductMediaDeleteCommand: ICommandFunc<int, OperationResponse<ProductMediaDeleteCommandOutputDTO>>
    {
    }
}