﻿using ApplicationLogic.Business.Commands.ProductColorType.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.ProductColorType.GetAllCommand
{
    public interface IProductColorTypeGetAllCommand: ICommandAction<OperationResponse<IEnumerable<ProductColorTypeGetAllCommandOutputDTO>>>
    {
    }
}