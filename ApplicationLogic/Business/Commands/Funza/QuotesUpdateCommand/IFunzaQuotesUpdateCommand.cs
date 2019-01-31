using ApplicationLogic.Business.Commands.Funza.QuotesUpdateCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Funza.QuotesUpdateCommand.Models
{
    public interface IFunzaQuotesUpdateCommand: ICommandFunc<IEnumerable<FunzaQuotesUpdateCommandInputDTO>, OperationResponse<FunzaQuotesUpdateCommandOutputDTO>>
    {
    }
}