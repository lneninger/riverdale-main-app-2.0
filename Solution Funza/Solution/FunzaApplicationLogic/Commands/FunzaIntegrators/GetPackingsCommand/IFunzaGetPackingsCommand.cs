using FunzaApplicationLogic.Commands.FunzaIntegrators.GetPackingsCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace FunzaApplicationLogic.Commands.FunzaIntegrators.GetPackingsCommand
{
    public interface IFunzaGetPackingsCommand : ICommandAction<OperationResponse<IEnumerable<FunzaGetPackingsCommandOutputDTO>>>
    {
    }
}