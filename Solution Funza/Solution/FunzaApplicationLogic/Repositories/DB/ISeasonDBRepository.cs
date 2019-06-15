using DomainModel;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using FunzaApplicationLogic.Commands.Funza.Season.SeasonGetByFunzaIdCommand.Models;
using FunzaApplicationLogic.Commands.Season.SeasonPageQueryCommand.Models;
using FunzaApplicationLogic.Repositories.DB;

namespace ApplicationLogic.Repositories.DB
{
    public interface ISeasonDBRepository: IDBRepository
    {
        OperationResponse<Season> GetById(int id);

        OperationResponse Add(Season entity);

        OperationResponse<Season> GetByFunzaId(int id);

        OperationResponse<PageResult<SeasonPageQueryCommandOutput>> PageQuery(PageQuery<SeasonPageQueryCommandInput> input);
    }
}
