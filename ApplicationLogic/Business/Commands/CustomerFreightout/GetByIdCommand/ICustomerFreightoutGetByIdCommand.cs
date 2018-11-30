using ApplicationLogic.Business.Commands.CustomerFreightout.GetByIdCommand.Models;
using System;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.GetByIdCommand
{
    public interface ICustomerFreightoutGetByIdCommand: ICommandFunc<int, CustomerFreightoutGetByIdCommandOutputDTO>
    {
    }
}