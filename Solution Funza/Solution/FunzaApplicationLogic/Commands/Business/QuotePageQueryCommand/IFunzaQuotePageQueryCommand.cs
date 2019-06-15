using FunzaApplicationLogic.Commands.Funza.QuotePageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace FunzaApplicationLogic.Commands.Funza.QuotePageQueryCommand
{
    public interface IFunzaQuotePageQueryCommand: ICommandFunc<PageQuery<QuotePageQueryCommandInput>, OperationResponse<PageResult<QuotePageQueryCommandOutput>>>
    {
    }
}