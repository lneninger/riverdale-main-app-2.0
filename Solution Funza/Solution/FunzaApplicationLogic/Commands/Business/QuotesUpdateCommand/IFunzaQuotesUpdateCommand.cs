using FunzaApplicationLogic.Commands.Funza.QuotesUpdateCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace FunzaApplicationLogic.Commands.Funza.QuotesUpdateCommand.Models
{
    public interface IFunzaQuotesUpdateCommand: ICommandFunc<IEnumerable<FunzaQuotesUpdateCommandInputDTO>, OperationResponse<FunzaQuotesUpdateCommandOutputDTO>>
    {
    }
}