using FunzaApplicationLogic.Commands.Season.SeasonPageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using Framework.Commands;

namespace FunzaApplicationLogic.Commands.Season.SeasonPageQueryCommand
{
    public interface ISeasonPageQueryCommand: ICommandFunc<PageQuery<SeasonPageQueryCommandInput>, OperationResponse<PageResult<SeasonPageQueryCommandOutput>>>
    {
    }
}