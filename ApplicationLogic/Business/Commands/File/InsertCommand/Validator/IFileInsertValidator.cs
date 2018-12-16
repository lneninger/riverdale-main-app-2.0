using ApplicationLogic.Business.Commands.File.InsertCommand.Models;
using ApplicationLogic.Business.Commons.Validators;
using Framework.Storage.DataHolders.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.File.RegisterValidator
{
    public interface IFileInsertValidator: IValidator<FileInsertCommandInputDTO>
    {
    }
}