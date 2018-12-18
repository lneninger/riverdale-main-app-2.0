using ApplicationLogic.Business.Commands.Customer.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Customer.GetAllCommand
{
    public interface ICustomerGetAllCommand: ICommandAction<OperationResponse<IEnumerable<CustomerGetAllCommandOutputDTO>>>
    {
    }
}