using ApplicationLogic.Business.Commands.ProductCategoryAllowedSize.PageQueryCommand.Models;
using DomainModel.Product;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Repositories.DB
{
    public interface IProductCategoryAllowedSizeDBRepository: IDBRepository
    {
        OperationResponse<IEnumerable<ProductCategoryAllowedSize>> GetAll();

        OperationResponse<PageResult<ProductCategoryAllowedSizePageQueryCommandOutputDTO>> PageQuery(PageQuery<ProductCategoryAllowedSizePageQueryCommandInputDTO> input);

        OperationResponse<DomainModel.Product.ProductCategoryAllowedSize> GetById(int id);

        OperationResponse Insert(ProductCategoryAllowedSize entity);

        OperationResponse Delete(ProductCategoryAllowedSize entity);

        OperationResponse LogicalDelete(ProductCategoryAllowedSize entity);

    }
}
