using ApplicationLogic.Business.Commands.ProductAllowedColorType.InsertCommand.Models;
using ApplicationLogic.Business.Commons.Validators;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductAllowedColorType.RegisterValidator
{
    public interface IProductAllowedColorTypeInsertValidator: IValidator<ProductAllowedColorTypeInsertCommandInputDTO>
    {
    }
}