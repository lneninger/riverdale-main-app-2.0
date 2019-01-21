using ApplicationLogic.Business.Commands.FunzaIntegrator.GetCategoriesCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.FunzaIntegrator.GetCategoriesCommand
{
    public interface IFunzaGetCategoriesCommand : ICommandAction<OperationResponse<IEnumerable<FunzaGetCategoriesCommandOutputDTO>>>
    {
    }
}