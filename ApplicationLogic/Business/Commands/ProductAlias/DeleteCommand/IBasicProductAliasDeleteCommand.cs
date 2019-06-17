using ApplicationLogic.Business.Commands.BasicProductAlias.DeleteCommand.Models;
using Framework.Core.Messages;
using System;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.BasicProductAlias.DeleteCommand
{
    public interface IBasicProductAliasDeleteCommand: ICommandFunc<int, OperationResponse<BasicProductAliasDeleteCommandOutputDTO>>
    {
    }
}