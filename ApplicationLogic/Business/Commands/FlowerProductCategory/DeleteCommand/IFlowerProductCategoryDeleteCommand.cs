using ApplicationLogic.Business.Commands.FlowerProductCategory.DeleteCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.FlowerProductCategory.DeleteCommand
{
    public interface IFlowerProductCategoryDeleteCommand : ICommandFunc<string, OperationResponse<FlowerProductCategoryDeleteCommandOutputDTO>>
    {
    }
}