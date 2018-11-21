using ApplicationLogic.Business.Commands.Customer.InsertCommand.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Customer.InsertCommand
{
    public interface ICustomerInsertCommand: ICommandFunc<CustomerInsertCommandInputDTO, CustomerInsertCommandOutputDTO>
    {
    }
}