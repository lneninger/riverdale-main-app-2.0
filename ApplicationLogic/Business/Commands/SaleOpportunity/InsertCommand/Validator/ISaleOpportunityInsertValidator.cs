using ApplicationLogic.Business.Commands.SaleOpportunity.InsertCommand.Models;
using ApplicationLogic.Business.Commons.Validators;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunity.RegisterValidator
{
    public interface ISaleOpportunityInsertValidator: IValidator<SaleOpportunityInsertCommandInputDTO>
    {
    }
}