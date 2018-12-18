using ApplicationLogic.Business.Commands.CustomerFreightout.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.PageQueryCommand
{
    public interface ICustomerFreightoutPageQueryCommand: ICommandFunc<PageQuery<CustomerFreightoutPageQueryCommandInputDTO>, OperationResponse<PageResult<CustomerFreightoutPageQueryCommandOutputDTO>>>
    {
    }
}