﻿using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Product.InsertCommand.Models;
using Framework.Core.Crypto;
using Framework.Core.Messages;
using FluentValidation;

namespace ApplicationLogic.Business.Commands.Product.InsertCommand
{
    public class SaleOpportunityTargetPriceProductInsertValidator : FluentValidation.AbstractValidator<ProductInsertCommandInputDTO>
    {
        public SaleOpportunityTargetPriceProductInsertValidator()
        {
            // Email Required
            this.RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}