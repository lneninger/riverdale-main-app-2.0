using FunzaApplicationLogic.Commands.FunzaIntegrators.GetSizesCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;
using Framework.Commands;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System.Threading.Tasks;
using FunzaDirectClients.Clients.Sizes.Models;

namespace FunzaApplicationLogic.Commands.FunzaIntegrators.GetSizesCommand
{
    public interface IFunzaGetSizesCommand : ICommandFuncAsync<PageQuery<FunzaGetSizesCommandInput>, OperationResponse<IEnumerable<FunzaGetSizesCommandOutput>>>
    {
    }
}