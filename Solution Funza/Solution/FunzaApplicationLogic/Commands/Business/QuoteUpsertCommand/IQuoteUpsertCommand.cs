using FunzaApplicationLogic.Commands.Funza.QuoteUpsertCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;
using Framework.Commands;

namespace FunzaApplicationLogic.Commands.Funza.QuoteUpsertCommand
{
    public interface IQuoteUpsertCommand: ICommandFunc<QuoteUpsertCommandInput, OperationResponse<QuoteUpsertCommandOutput>>
    {
    }
}