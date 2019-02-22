using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.InsertCommand.Models;
using Framework.Core.Crypto;
using Framework.Core.Messages;
using FluentValidation;

namespace ApplicationLogic.Business.Commands.SaleOpportunityPriceLevel.InsertCommand
{
    public class SaleOpportunityPriceLevelInsertValidator : FluentValidation.AbstractValidator<SaleOpportunityPriceLevelInsertCommandInputDTO>
    {
        public SaleOpportunityPriceLevelInsertValidator()
        {
            // Email Required
            this.RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
