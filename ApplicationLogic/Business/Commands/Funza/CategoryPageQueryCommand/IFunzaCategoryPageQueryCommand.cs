using ApplicationLogic.Business.Commands.Funza.CategoryPageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Funza.CategoryPageQueryCommand
{
    public interface IFunzaCategoryPageQueryCommand: ICommandFunc<PageQuery<FunzaCategoryPageQueryCommandInputDTO>, OperationResponse<PageResult<FunzaCategoryPageQueryCommandOutputDTO>>>
    {
    }
}