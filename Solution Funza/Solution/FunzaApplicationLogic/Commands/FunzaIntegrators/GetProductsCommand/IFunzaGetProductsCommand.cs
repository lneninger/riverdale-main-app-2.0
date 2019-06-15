using FunzaApplicationLogic.Commands.FunzaIntegrators.GetProductsCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Commands;

namespace FunzaApplicationLogic.Commands.FunzaIntegrators.GetProductsCommand
{
    public interface IFunzaGetProductsCommand : ICommandFuncAsync<PageQuery<FunzaGetProductsCommandInput>, OperationResponse<PageResult<FunzaGetProductsCommandOutput>>>
    {
    }
}