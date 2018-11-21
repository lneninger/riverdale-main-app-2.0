using ApplicationLogic.Business.Commands.Customer.GetByIdCommand.Models;
using System;

namespace ApplicationLogic.Business.Commands.Customer.GetByIdCommand
{
    public interface ICustomerGetByIdCommand: ICommandFunc<int, CustomerGetByIdCommandOutputDTO>
    {
    }
}