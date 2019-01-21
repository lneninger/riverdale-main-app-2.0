using ApplicationLogic.Business.Commands.FunzaIntegrator.GetColorsCommand.Models;
using ApplicationLogic.Business.Commands.Product.DeleteCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.FunzaIntegrator.GetColorsCommand
{
    public interface IFunzaGetColorsCommand : ICommandAction<OperationResponse<IEnumerable<FunzaGetColorsCommandOutputDTO>>>
    {
    }
}