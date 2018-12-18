using ApplicationLogic.Business.Commands.CustomerFreightout.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.GetAllCommand
{
    public interface ICustomerFreightoutGetAllCommand: ICommandAction<OperationResponse<IEnumerable<CustomerFreightoutGetAllCommandOutputDTO>>>
    {
    }
}