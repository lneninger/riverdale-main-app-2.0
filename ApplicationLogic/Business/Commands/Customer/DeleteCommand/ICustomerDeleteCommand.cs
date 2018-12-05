using ApplicationLogic.Business.Commands.Customer.DeleteCommand.Models;
using Framework.Storage.DataHolders.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Customer.DeleteCommand
{
    public interface ICustomerDeleteCommand: ICommandFunc<int, OperationResponse<CustomerDeleteCommandOutputDTO>>
    {
    }
}