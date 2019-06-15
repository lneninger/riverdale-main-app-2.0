using Framework.Core.Messages;
using Framework.Commands;
using FunzaApplicationLogic.Commands.Funza.Season.SeasonGetByFunzaIdCommand.Models;

namespace FunzaApplicationLogic.Commands.Funza.Season.SeasonGetByFunzaIdCommand
{
    public interface ISeasonGetByFunzaIdCommand : ICommandFunc<SeasonGetByFunzaIdCommandInput, OperationResponse<SeasonGetByFunzaIdCommandOutput>>
    {
    }
}