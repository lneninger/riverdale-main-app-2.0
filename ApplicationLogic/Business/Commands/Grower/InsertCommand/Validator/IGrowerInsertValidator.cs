using ApplicationLogic.Business.Commands.Grower.InsertCommand.Models;
using ApplicationLogic.Business.Commons.Validators;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Grower.RegisterValidator
{
    public interface IGrowerInsertValidator: IValidator<GrowerInsertCommandInputDTO>
    {
    }
}