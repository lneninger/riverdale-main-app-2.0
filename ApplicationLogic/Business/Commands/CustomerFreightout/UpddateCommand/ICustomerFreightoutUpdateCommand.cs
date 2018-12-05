using ApplicationLogic.Business.Commands.CustomerFreightout.UpdateCommand.Models;
using Framework.Storage.DataHolders.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.CustomerFreightout.UpdateCommand
{
    public interface ICustomerFreightoutUpdateCommand: ICommandFunc<CustomerFreightoutUpdateCommandInputDTO, OperationResponse<CustomerFreightoutUpdateCommandOutputDTO>>
    {
    }
}