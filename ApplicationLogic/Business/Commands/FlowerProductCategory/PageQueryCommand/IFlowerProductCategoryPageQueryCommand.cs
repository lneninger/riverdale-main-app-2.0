using ApplicationLogic.Business.Commands.FlowerProductCategory.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.FlowerProductCategory.PageQueryCommand
{
    public interface IFlowerProductCategoryPageQueryCommand: ICommandFunc<PageQuery<FlowerProductCategoryPageQueryCommandInputDTO>, OperationResponse<PageResult<FlowerProductCategoryPageQueryCommandOutputDTO>>>
    {
    }
}