using ApplicationLogic.Business.Commands.BasicProductAlias.GetAllCommand.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.BasicProductAlias.GetAllCommand
{
    public interface IBasicProductAliasGetAllCommand: ICommandAction<OperationResponse<IEnumerable<BasicProductAliasGetAllCommandOutputDTO>>>
    {
    }
}