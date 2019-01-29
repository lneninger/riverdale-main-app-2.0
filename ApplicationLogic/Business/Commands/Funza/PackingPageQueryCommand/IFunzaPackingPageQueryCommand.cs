using ApplicationLogic.Business.Commands.Funza.PackingPageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Funza.PackingPageQueryCommand
{
    public interface IFunzaPackingPageQueryCommand: ICommandFunc<PageQuery<FunzaPackingPageQueryCommandInputDTO>, OperationResponse<PageResult<FunzaPackingPageQueryCommandOutputDTO>>>
    {
    }
}