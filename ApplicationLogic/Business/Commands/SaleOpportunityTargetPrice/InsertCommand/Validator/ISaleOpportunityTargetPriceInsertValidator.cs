using ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.InsertCommand.Models;
using ApplicationLogic.Business.Commons.Validators;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.RegisterValidator
{
    public interface ISaleOpportunityTargetPriceInsertValidator : IValidator<SaleOpportunityTargetPriceInsertCommandInputDTO>
    {
    }
}