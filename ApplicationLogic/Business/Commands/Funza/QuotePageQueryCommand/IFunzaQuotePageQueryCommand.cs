using ApplicationLogic.Business.Commands.Funza.QuotePageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Funza.QuotePageQueryCommand
{
    public interface IFunzaQuotePageQueryCommand: ICommandFunc<PageQuery<FunzaQuotePageQueryCommandInputDTO>, OperationResponse<PageResult<FunzaQuotePageQueryCommandOutputDTO>>>
    {
    }
}