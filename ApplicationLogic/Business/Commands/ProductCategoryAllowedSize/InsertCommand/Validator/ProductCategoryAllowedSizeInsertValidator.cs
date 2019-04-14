using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.InsertCommand.Models;
using Framework.Core.Crypto;
using Framework.Core.Messages;
using FluentValidation;

namespace ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.InsertCommand
{
    public class ProductCategoryAllowedSizeInsertValidator : FluentValidation.AbstractValidator<ProductCategoryAllowedSizeInsertCommandInputDTO>
    {
        public ProductCategoryAllowedSizeInsertValidator()
        {
            // Email Required
            //this.RuleFor(x => x.Name)
            //    .NotEmpty();
        }
    }
}
