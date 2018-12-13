﻿using ApplicationLogic.Business.Commands.Product.InsertCommand.Models;
using ApplicationLogic.Business.Commons.Validators;
using Framework.Storage.DataHolders.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Product.RegisterValidator
{
    public interface IProductInsertValidator: IValidator<ProductInsertCommandInputDTO>
    {
    }
}