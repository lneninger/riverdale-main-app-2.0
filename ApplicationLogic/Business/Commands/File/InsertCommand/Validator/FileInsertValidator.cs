using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.File.InsertCommand.Models;
using Framework.Core.Crypto;
using Framework.Storage.DataHolders.Messages;
using FluentValidation;

namespace ApplicationLogic.Business.Commands.File.InsertCommand
{
    public class FileInsertValidator : FluentValidation.AbstractValidator<FileInsertCommandInputDTO>
    {
        public FileInsertValidator()
        {
            // Email Required
            this.RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
