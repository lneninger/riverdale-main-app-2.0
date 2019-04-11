using ApplicationLogic.Business.Commands.FlowerProductCategory.InsertCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.FlowerProductCategory.InsertCommand
{
    public interface IFlowerProductCategoryInsertCommand: ICommandFunc<FlowerProductCategoryInsertCommandInputDTO, OperationResponse<FlowerProductCategoryInsertCommandOutputDTO>>
    {
    }
}