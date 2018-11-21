using ApplicationLogic.Business.Commands.Customer.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Customer.PageQueryCommand
{
    public interface ICustomerPageQueryCommand: ICommandFunc<PageQuery<CustomerPageQueryCommandInputDTO>, PageResult<CustomerPageQueryCommandOutputDTO>>
    {
    }
}