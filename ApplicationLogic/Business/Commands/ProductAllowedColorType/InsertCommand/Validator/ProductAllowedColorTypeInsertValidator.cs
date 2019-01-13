using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductAllowedColorType.InsertCommand.Models;
using Framework.Core.Crypto;
using Framework.Core.Messages;
using FluentValidation;

namespace ApplicationLogic.Business.Commands.ProductAllowedColorType.InsertCommand
{
    public class ProductAllowedColorTypeInsertValidator : FluentValidation.AbstractValidator<ProductAllowedColorTypeInsertCommandInputDTO>
    {
        public ProductAllowedColorTypeInsertValidator()
        {
            // Email Required
            //this.RuleFor(x => x.Name)
            //    .NotEmpty();
        }
    }
}
