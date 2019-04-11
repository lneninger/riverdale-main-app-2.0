using ApplicationLogic.Business.Commands.Funza.CategoryPageQueryCommand.Models;
using DomainModel.Funza;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;

namespace ApplicationLogic.Repositories.DB
{
    public interface IFunzaCategoryReferenceDBRepository : IDBRepository
    {
        OperationResponse<DomainModel.Funza.CategoryReference> GetById(int id);

        OperationResponse Add(CategoryReference entity);

        OperationResponse<CategoryReference> GetByFunzaId(int id);

        OperationResponse<PageResult<FunzaCategoryPageQueryCommandOutputDTO>> PageQuery(PageQuery<FunzaCategoryPageQueryCommandInputDTO> input);

    }
}
