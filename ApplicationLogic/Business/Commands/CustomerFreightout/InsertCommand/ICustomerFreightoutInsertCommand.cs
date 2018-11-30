using ApplicationLogic.Business.Commands.CustomerFreightout.InsertCommand.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.InsertCommand
{
    public interface ICustomerFreightoutInsertCommand: ICommandFunc<CustomerFreightoutInsertCommandInputDTO, CustomerFreightoutInsertCommandOutputDTO>
    {
    }
}