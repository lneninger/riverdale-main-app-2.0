using ApplicationLogic.Business.Commands.BasicProductAlias.UpdateCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.BasicProductAlias.UpdateCommand
{
    public interface IBasicProductAliasUpdateCommand: ICommandFunc<BasicProductAliasUpdateCommandInputDTO, OperationResponse<BasicProductAliasUpdateCommandOutputDTO>>
    {
    }
}