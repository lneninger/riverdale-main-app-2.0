using ApplicationLogic.Business.Commands.Customer.UpdateCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Customer.UpdateCommand
{
    public interface ICustomerUpdateCommand: ICommandFunc<CustomerUpdateCommandInputDTO, OperationResponse<CustomerUpdateCommandOutputDTO>>
    {
    }
}