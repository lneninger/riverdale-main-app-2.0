using ApplicationLogic.Business.Commands.Customer.GetAllCommand.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Customer.GetAllCommand
{
    public interface ICustomerGetAllCommand: ICommandAction<IEnumerable<CustomerPageQueryCommandOutputDTO>>
    {
    }
}