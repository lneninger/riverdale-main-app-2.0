using ApplicationLogic.Business.Commands.Customer.UpdateCommand.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Customer.UpdateCommand
{
    public interface ICustomerUpdateCommand: ICommandFunc<CustomerUpdateCommandInputDTO, CustomerUpdateCommandOutputDTO>
    {
    }
}