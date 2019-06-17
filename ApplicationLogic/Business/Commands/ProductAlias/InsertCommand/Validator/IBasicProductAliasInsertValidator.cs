using ApplicationLogic.Business.Commands.BasicProductAlias.InsertCommand.Models;
using ApplicationLogic.Business.Commons.Validators;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.BasicProductAlias.RegisterValidator
{
    public interface IBasicProductAliasInsertValidator: IValidator<BasicProductAliasInsertCommandInputDTO>
    {
    }
}