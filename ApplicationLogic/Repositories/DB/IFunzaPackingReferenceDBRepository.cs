using ApplicationLogic.Business.Commands.Funza.PackingPageQueryCommand.Models;
using DomainModel.Funza;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;

namespace ApplicationLogic.Repositories.DB
{
    public interface IFunzaPackingReferenceDBRepository : IDBRepository
    {
        OperationResponse<DomainModel.Funza.PackingReference> GetById(int id);

        OperationResponse Add(PackingReference entity);

        OperationResponse<PackingReference> GetByFunzaId(int id);

        OperationResponse<PageResult<FunzaPackingPageQueryCommandOutputDTO>> PageQuery(PageQuery<FunzaPackingPageQueryCommandInputDTO> input);

    }
}
