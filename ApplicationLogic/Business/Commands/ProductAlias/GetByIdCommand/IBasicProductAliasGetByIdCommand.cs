using ApplicationLogic.Business.Commands.BasicProductAlias.GetByIdCommand.Models;
using Framework.Core.Messages;
using System;

namespace ApplicationLogic.Business.Commands.BasicProductAlias.GetByIdCommand
{
    public interface IBasicProductAliasGetByIdCommand: ICommandFunc<int, OperationResponse<BasicProductAliasGetByIdCommandOutputDTO>>
    {
    }
}