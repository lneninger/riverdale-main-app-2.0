using ApplicationLogic.Business.Commands.ProductCategory.InsertCommand.Models;
using ApplicationLogic.Business.Commons.Validators;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductCategory.RegisterValidator
{
    public interface IProductCategoryInsertValidator: IValidator<ProductCategoryInsertCommandInputDTO>
    {
    }
}