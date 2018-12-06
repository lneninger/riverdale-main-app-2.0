using ApplicationLogic.Business.Commands.CustomerFreightout.GetByIdCommand.Models;
using Framework.Storage.DataHolders.Messages;
using System;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.GetByIdCommand
{
    public interface ICustomerFreightoutGetByIdCommand: ICommandFunc<int, OperationResponse<CustomerFreightoutGetByIdCommandOutputDTO>>
    {
    }
}