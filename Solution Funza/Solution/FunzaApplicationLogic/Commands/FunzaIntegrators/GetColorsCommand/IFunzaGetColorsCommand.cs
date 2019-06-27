using FunzaApplicationLogic.Commands.FunzaIntegrators.GetColorsCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Commands;
using FunzaDirectClients.Clients.ProductColor.Models;

namespace FunzaApplicationLogic.Commands.FunzaIntegrators.GetColorsCommand
{
    public interface IFunzaGetColorsCommand : ICommandFuncAsync<PageQuery<FunzaGetColorsCommandInput>, OperationResponse<IEnumerable<DirectGetProductColorsResult>>>
    {
    }
}