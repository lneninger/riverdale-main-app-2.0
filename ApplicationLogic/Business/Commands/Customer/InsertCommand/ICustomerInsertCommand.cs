using FocusServices.Business.Commands.Customer.InsertCommand.Models;
using System.Collections.Generic;

namespace FocusServices.Business.Commands.Customer.InsertCommand
{
    public interface ICustomerInsertCommand: ICommandFunc<CustomerInsertCommandInputDTO, CustomerInsertCommandOutputDTO>
    {
    }
}