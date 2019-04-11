using ApplicationLogic.Business.Commands.FlowerProductCategory.GetByIdCommand.Models;
using Framework.Core.Messages;
using System;

namespace ApplicationLogic.Business.Commands.FlowerProductCategory.GetByIdCommand
{
    public interface IFlowerProductCategoryGetByIdCommand: ICommandFunc<string, OperationResponse<FlowerProductCategoryGetByIdCommandOutputDTO>>
    {
    }
}