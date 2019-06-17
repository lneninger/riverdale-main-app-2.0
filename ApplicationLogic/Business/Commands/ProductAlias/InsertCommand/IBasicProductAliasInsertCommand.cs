using ApplicationLogic.Business.Commands.BasicProductAlias.InsertCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.BasicProductAlias.InsertCommand
{
    public interface IBasicProductAliasInsertCommand: ICommandFunc<BasicProductAliasInsertCommandInputDTO, OperationResponse<BasicProductAliasInsertCommandOutputDTO>>
    {
    }
}