using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.Customer.InsertCommand.Models;
using Framework.Core.Crypto;
using Framework.Core.Messages;
using FluentValidation;

namespace ApplicationLogic.Business.Commands.Customer.InsertCommand
{
    public class CustomerInsertValidator : FluentValidation.AbstractValidator<CustomerInsertCommandInputDTO>
    {
        public CustomerInsertValidator()
        {
            // Email Required
            this.RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
