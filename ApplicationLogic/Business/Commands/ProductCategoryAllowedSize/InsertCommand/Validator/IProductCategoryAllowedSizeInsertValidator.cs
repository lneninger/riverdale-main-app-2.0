using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.InsertCommand.Models;
using ApplicationLogic.Business.Commons.Validators;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.RegisterValidator
{
    public interface IProductCategoryAllowedSizeInsertValidator: IValidator<ProductCategoryAllowedSizeInsertCommandInputDTO>
    {
    }
}