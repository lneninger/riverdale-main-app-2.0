using ApplicationLogic.Business.Commands.Customer.InsertCommand.Models;
using ApplicationLogic.Business.Commons.Validators;
using Framework.Storage.DataHolders.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Customer.RegisterValidator
{
    public interface ICustomerInsertValidator: IValidator<CustomerInsertCommandInputDTO>
    {
    }
}