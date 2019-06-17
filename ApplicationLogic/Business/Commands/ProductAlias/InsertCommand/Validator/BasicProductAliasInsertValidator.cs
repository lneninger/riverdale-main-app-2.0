using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.BasicProductAlias.InsertCommand.Models;
using Framework.Core.Crypto;
using Framework.Core.Messages;
using FluentValidation;

namespace ApplicationLogic.Business.Commands.BasicProductAlias.InsertCommand
{
    public class BasicProductAliasInsertValidator : FluentValidation.AbstractValidator<BasicProductAliasInsertCommandInputDTO>
    {
        public BasicProductAliasInsertValidator()
        {
            // Email Required
            this.RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
