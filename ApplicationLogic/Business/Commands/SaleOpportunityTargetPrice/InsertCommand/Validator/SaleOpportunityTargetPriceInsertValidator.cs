using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.InsertCommand.Models;
using Framework.Core.Crypto;
using Framework.Core.Messages;
using FluentValidation;

namespace ApplicationLogic.Business.Commands.SaleOpportunityTargetPrice.InsertCommand
{
    public class SaleOpportunityTargetPriceInsertValidator : FluentValidation.AbstractValidator<SaleOpportunityTargetPriceInsertCommandInputDTO>
    {
        public SaleOpportunityTargetPriceInsertValidator()
        {
            // Email Required
            this.RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
