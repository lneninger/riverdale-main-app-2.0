using ApplicationLogic.Business.Commands.Funza.ColorPageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Funza.ColorPageQueryCommand
{
    public interface IFunzaColorPageQueryCommand: ICommandFunc<PageQuery<FunzaColorPageQueryCommandInputDTO>, OperationResponse<PageResult<FunzaColorPageQueryCommandOutputDTO>>>
    {
    }
}