using ApplicationLogic.Business.Commands.Customer.UpdateCommand.Models;
using Framework.Storage.DataHolders.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Customer.UpdateCommand
{
    public interface ICustomerUpdateCommand: ICommandFunc<CustomerUpdateCommandInputDTO, OperationResponse<CustomerUpdateCommandOutputDTO>>
    {
    }
}