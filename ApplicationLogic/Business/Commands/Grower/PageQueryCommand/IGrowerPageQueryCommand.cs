using ApplicationLogic.Business.Commands.Grower.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Grower.PageQueryCommand
{
    public interface IGrowerPageQueryCommand: ICommandFunc<PageQuery<GrowerPageQueryCommandInputDTO>, OperationResponse<PageResult<GrowerPageQueryCommandOutputDTO>>>
    {
    }
}