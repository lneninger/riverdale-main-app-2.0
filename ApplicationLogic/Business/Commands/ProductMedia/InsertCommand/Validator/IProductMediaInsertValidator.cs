using ApplicationLogic.Business.Commands.ProductMedia.InsertCommand.Models;
using ApplicationLogic.Business.Commons.Validators;
using Framework.Storage.DataHolders.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductMedia.RegisterValidator
{
    public interface IProductMediaInsertValidator: IValidator<ProductMediaInsertCommandInputDTO>
    {
    }
}