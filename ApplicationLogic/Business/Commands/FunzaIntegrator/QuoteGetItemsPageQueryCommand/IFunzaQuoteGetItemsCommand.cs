using ApplicationLogic.Business.Commands.Funza.PackingPageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.Funza.PackingPageQueryCommand
{
    public interface IFunzaQuoteGetItemsCommand: ICommandFunc<PageQuery<FunzaQuoteGetItemsCommandInputDTO>, OperationResponse<PageResult<FunzaQuoteGetItemsCommandOutputDTO>>>
    {
    }
}