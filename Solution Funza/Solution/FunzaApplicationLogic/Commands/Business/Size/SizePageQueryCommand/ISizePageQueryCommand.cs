using FunzaApplicationLogic.Commands.Size.SizePageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using Framework.Commands;

namespace FunzaApplicationLogic.Commands.Size.SizePageQueryCommand
{
    public interface ISizePageQueryCommand: ICommandFunc<PageQuery<SizePageQueryCommandInput>, OperationResponse<PageResult<SizePageQueryCommandOutput>>>
    {
    }
}