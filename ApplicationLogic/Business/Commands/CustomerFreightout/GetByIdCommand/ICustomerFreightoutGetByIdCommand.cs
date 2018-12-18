using ApplicationLogic.Business.Commands.CustomerFreightout.GetByIdCommand.Models;
using Framework.Core.Messages;
using System;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.GetByIdCommand
{
    public interface ICustomerFreightoutGetByIdCommand: ICommandFunc<int, OperationResponse<CustomerFreightoutGetByIdCommandOutputDTO>>
    {
    }
}