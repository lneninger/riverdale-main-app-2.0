using FocusServices.Business.Commands.Customer.GetAllCommand.Models;
using System.Collections.Generic;

namespace FocusServices.Business.Commands.Customer.GetAllCommand
{
    public interface ICustomerGetAllCommand: ICommandAction<IEnumerable<CustomerGetAllCommandOutputDTO>>
    {
    }
}