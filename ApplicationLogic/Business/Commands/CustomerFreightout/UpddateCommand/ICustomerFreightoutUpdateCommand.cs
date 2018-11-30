using ApplicationLogic.Business.Commands.CustomerFreightout.UpdateCommand.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.UpdateCommand
{
    public interface ICustomerFreightoutUpdateCommand: ICommandFunc<CustomerFreightoutUpdateCommandInputDTO, CustomerFreightoutUpdateCommandOutputDTO>
    {
    }
}