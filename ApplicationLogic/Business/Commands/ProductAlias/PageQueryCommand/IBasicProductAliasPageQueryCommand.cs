using ApplicationLogic.Business.Commands.BasicProductAlias.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;

namespace ApplicationLogic.Business.Commands.BasicProductAlias.PageQueryCommand
{
    public interface IBasicProductAliasPageQueryCommand: ICommandFunc<PageQuery<BasicProductAliasPageQueryCommandInputDTO>, OperationResponse<PageResult<BasicProductAliasPageQueryCommandOutputDTO>>>
    {
    }
}