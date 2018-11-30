using ApplicationLogic.Business.Commands.CustomerFreightout.DeleteCommand.Models;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.DeleteCommand
{
    public interface ICustomerFreightoutDeleteCommand: ICommandFunc<int, CustomerFreightoutDeleteCommandOutputDTO>
    {
    }
}