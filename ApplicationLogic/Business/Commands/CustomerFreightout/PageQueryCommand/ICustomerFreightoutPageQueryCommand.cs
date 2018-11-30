using ApplicationLogic.Business.Commands.CustomerFreightout.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.PageQueryCommand
{
    public interface ICustomerFreightoutPageQueryCommand: ICommandFunc<PageQuery<CustomerFreightoutPageQueryCommandInputDTO>, PageResult<CustomerFreightoutPageQueryCommandOutputDTO>>
    {
    }
}