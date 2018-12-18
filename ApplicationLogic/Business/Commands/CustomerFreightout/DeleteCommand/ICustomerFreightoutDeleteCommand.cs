using ApplicationLogic.Business.Commands.CustomerFreightout.DeleteCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.DeleteCommand
{
    public interface ICustomerFreightoutDeleteCommand: ICommandFunc<int, OperationResponse<CustomerFreightoutDeleteCommandOutputDTO>>
    {
    }
}