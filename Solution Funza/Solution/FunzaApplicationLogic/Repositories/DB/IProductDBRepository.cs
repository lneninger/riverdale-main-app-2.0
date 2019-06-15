using ApplicationLogic.Business.Commands.Funza.ProductPageQueryCommand.Models;
using DomainModel.Funza;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;

namespace ApplicationLogic.Repositories.DB
{
    public interface IProductDBRepository: IDBRepository
    {
        OperationResponse<DomainModel.Funza.ProductReference> GetById(int id);

        OperationResponse Add(ProductReference entity);

        OperationResponse<ProductReference> GetByFunzaId(int id);

        OperationResponse<PageResult<FunzaProductPageQueryCommandOutputDTO>> PageQuery(PageQuery<FunzaProductPageQueryCommandInputDTO> input);
    }
}
