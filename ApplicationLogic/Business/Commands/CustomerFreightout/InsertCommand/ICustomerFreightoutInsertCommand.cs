using ApplicationLogic.Business.Commands.CustomerFreightout.InsertCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.InsertCommand
{
    public interface ICustomerFreightoutInsertCommand: ICommandFunc<CustomerFreightoutInsertCommandInputDTO, OperationResponse<CustomerFreightoutInsertCommandOutputDTO>>
    {
    }
}