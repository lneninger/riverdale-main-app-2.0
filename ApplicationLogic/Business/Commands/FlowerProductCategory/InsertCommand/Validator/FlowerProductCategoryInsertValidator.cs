using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.FlowerProductCategory.InsertCommand.Models;
using Framework.Core.Crypto;
using Framework.Core.Messages;
using FluentValidation;

namespace ApplicationLogic.Business.Commands.FlowerProductCategory.InsertCommand
{
    public class FlowerProductCategoryInsertValidator : FluentValidation.AbstractValidator<FlowerProductCategoryInsertCommandInputDTO>
    {
        public FlowerProductCategoryInsertValidator()
        {
            // Email Required
            this.RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
