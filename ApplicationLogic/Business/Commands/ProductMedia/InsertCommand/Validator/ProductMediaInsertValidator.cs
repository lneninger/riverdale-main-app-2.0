using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductMedia.InsertCommand.Models;
using Framework.Core.Crypto;
using Framework.Storage.DataHolders.Messages;
using FluentValidation;

namespace ApplicationLogic.Business.Commands.ProductMedia.InsertCommand
{
    public class ProductMediaInsertValidator : FluentValidation.AbstractValidator<ProductMediaInsertCommandInputDTO>
    {
        public ProductMediaInsertValidator()
        {
            // Email Required
            this.RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
