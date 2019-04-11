using ApplicationLogic.Business.Commands.FlowerProductCategory.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.FlowerProductCategory.GetAllCommand
{
    public interface IFlowerProductCategoryGetAllCommand : ICommandAction<OperationResponse<IEnumerable<FlowerProductCategoryGetAllCommandOutputDTO>>>
    {
    }
}