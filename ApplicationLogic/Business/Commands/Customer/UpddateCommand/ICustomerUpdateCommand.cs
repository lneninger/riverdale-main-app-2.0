using FocusServices.Business.Commands.Customer.UpdateCommand.Models;
using System.Collections.Generic;

namespace FocusServices.Business.Commands.Customer.UpdateCommand
{
    public interface ICustomerUpdateCommand: ICommandFunc<CustomerUpdateCommandInputDTO, CustomerUpdateCommandOutputDTO>
    {
    }
}