using FunzaApplicationLogic.Commands.Funza.Season.SeasonMapCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;
using System.Collections.Generic;
using Framework.Commands;

namespace FunzaApplicationLogic.Commands.Funza.Season.SeasonCommand
{
    public interface ISeasonMapCommand: ICommandFunc<SeasonMapCommandInput, OperationResponse<SeasonMapCommandOutput>>
    {
    }
}