using FunzaApplicationLogic.Commands.FunzaIntegrators.GetCategoriesCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;
using Framework.Commands;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System.Threading.Tasks;
using FunzaDirectClients.Clients.ProductCategory.Models;

namespace FunzaApplicationLogic.Commands.FunzaIntegrators.GetCategoriesCommand
{
    public interface IFunzaGetCategoriesCommand : ICommandFuncAsync<PageQuery<FunzaGetCategoriesCommandInput>, OperationResponse<IEnumerable<DirectGetProductCategoriesResult>>>
    {
    }
}