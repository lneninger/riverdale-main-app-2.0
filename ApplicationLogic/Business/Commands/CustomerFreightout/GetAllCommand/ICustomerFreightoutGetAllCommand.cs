using ApplicationLogic.Business.Commands.CustomerFreightout.GetAllCommand.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.GetAllCommand
{
    public interface ICustomerFreightoutGetAllCommand: ICommandAction<IEnumerable<CustomerFreightoutGetAllCommandOutputDTO>>
    {
    }
}