using ApplicationLogic.Business.Commands.FunzaIntegrator.GetPackingsCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.FunzaIntegrator.GetPackingsCommand
{
    public interface IFunzaGetPackingsCommand : ICommandAction<OperationResponse<IEnumerable<FunzaGetPackingsCommandOutputDTO>>>
    {
    }
}