using ApplicationLogic.Business.Commands.Customer.DeleteCommand.Models;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Customer.DeleteCommand
{
    public interface ICustomerDeleteCommand: ICommandFunc<int, ProductColorDeleteCommandOutputDTO>
    {
    }
}