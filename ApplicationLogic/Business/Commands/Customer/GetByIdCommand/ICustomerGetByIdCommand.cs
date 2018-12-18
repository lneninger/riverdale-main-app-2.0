using ApplicationLogic.Business.Commands.Customer.GetByIdCommand.Models;
using Framework.Core.Messages;
using System;

namespace ApplicationLogic.Business.Commands.Customer.GetByIdCommand
{
    public interface ICustomerGetByIdCommand: ICommandFunc<int, OperationResponse<CustomerGetByIdCommandOutputDTO>>
    {
    }
}