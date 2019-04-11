using ApplicationLogic.Business.Commands.ProductBridge.PageQueryCommand.Models;
using DomainModel.Product;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Repositories.DB
{
    public interface IProductBridgeDBRepository: IDBRepository
    {
        OperationResponse<IEnumerable<CompositionProductBridge>> GetAll();

        OperationResponse<PageResult<ProductBridgePageQueryCommandOutputDTO>> PageQuery(PageQuery<ProductBridgePageQueryCommandInputDTO> input);

        OperationResponse<CompositionProductBridge> GetById(int id, bool forceRefresh = false);

        OperationResponse<CompositionProductBridge> GetByIdWithMedias(int id);

        OperationResponse Insert(CompositionProductBridge entity);

        OperationResponse Delete(CompositionProductBridge entity);

        OperationResponse LogicalDelete(CompositionProductBridge entity);

        void Detach(int id);

    }
}
