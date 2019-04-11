using ApplicationLogic.Business.Commands.FlowerProductCategory.InsertCommand.Models;
using ApplicationLogic.Business.Commons.Validators;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.FlowerProductCategory.RegisterValidator
{
    public interface IFlowerProductCategoryInsertValidator: IValidator<FlowerProductCategoryInsertCommandInputDTO>
    {
    }
}