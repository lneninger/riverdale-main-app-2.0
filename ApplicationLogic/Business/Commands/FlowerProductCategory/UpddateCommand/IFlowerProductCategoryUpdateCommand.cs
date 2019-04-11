using ApplicationLogic.Business.Commands.FlowerProductCategory.UpdateCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.FlowerProductCategory.UpdateCommand
{
    public interface IFlowerProductCategoryUpdateCommand: ICommandFunc<FlowerProductCategoryUpdateCommandInputDTO, OperationResponse<FlowerProductCategoryUpdateCommandOutputDTO>>
    {
    }
}