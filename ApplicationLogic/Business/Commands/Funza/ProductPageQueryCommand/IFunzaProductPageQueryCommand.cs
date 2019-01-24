using ApplicationLogic.Business.Commands.Funza.ProductPageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Funza.ProductPageQueryCommand
{
    public interface IFunzaProductPageQueryCommand: ICommandFunc<PageQuery<FunzaProductPageQueryCommandInputDTO>, OperationResponse<PageResult<FunzaProductPageQueryCommandOutputDTO>>>
    {
    }
}