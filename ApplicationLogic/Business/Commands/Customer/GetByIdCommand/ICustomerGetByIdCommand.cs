using FocusServices.Business.Commands.Customer.GetByIdCommand.Models;
using System;

namespace FocusServices.Business.Commands.Customer.GetByIdCommand
{
    public interface ICustomerGetByIdCommand: ICommandFunc<int, CustomerGetByIdCommandOutputDTO>
    {
    }
}