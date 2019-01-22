using ApplicationLogic.Business.Commands.FunzaIntegrator.GetQuotesCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.FunzaIntegrator.GetQuotesCommand
{
    public interface IFunzaGetQuotesCommand : ICommandAction<OperationResponse<IEnumerable<FunzaGetQuotesCommandOutputDTO>>>
    {
    }
}