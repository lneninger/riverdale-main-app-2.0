using DomainModel.Funza;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using FunzaApplicationLogic.Commands.Funza.PackingPageQueryCommand.Models;
using FunzaApplicationLogic.Repositories.DB;

namespace ApplicationLogic.Repositories.DB
{
    public interface IPackingDBRepository : IDBRepository
    {
        OperationResponse<DomainModel.Funza.Packing> GetById(int id);

        OperationResponse Add(Packing entity);

        OperationResponse<Packing> GetByFunzaId(int id);

        OperationResponse<PageResult<PackingPageQueryCommandOutput>> PageQuery(PageQuery<PackingPageQueryCommandInput> input);

    }
}
