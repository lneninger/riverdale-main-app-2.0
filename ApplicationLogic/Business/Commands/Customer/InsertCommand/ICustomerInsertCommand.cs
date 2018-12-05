using ApplicationLogic.Business.Commands.Customer.InsertCommand.Models;
using Framework.Storage.DataHolders.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Customer.InsertCommand
{
    public interface ICustomerInsertCommand: ICommandFunc<CustomerInsertCommandInputDTO, OperationResponse<CustomerInsertCommandOutputDTO>>
    {
    }
}