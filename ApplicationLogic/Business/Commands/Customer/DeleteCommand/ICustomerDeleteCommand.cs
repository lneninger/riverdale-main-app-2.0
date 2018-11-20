using FocusServices.Business.Commands.Customer.DeleteCommand.Models;
using System;
using System.Collections.Generic;

namespace FocusServices.Business.Commands.Customer.DeleteCommand
{
    public interface ICustomerDeleteCommand: ICommandFunc<int, CustomerDeleteCommandOutputDTO>
    {
    }
}