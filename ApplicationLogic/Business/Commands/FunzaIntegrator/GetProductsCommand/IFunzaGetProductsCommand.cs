using ApplicationLogic.Business.Commands.FunzaIntegrator.GetProductsCommand.Models;
using ApplicationLogic.Business.Commands.Product.DeleteCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.FunzaIntegrator.GetProductsCommand
{
    public interface IFunzaGetProductsCommand : ICommandAction<OperationResponse<IEnumerable<FunzaGetProductsCommandOutputDTO>>>
    {
    }
}