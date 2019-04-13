using ApplicationLogic.Business.Commands.ProductAllowedColorType.PageQueryCommand.Models;
using DomainModel.Product;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Repositories.DB
{
    public interface IProductAllowedColorTypeDBRepository: IDBRepository
    {
        OperationResponse<IEnumerable<ProductCategoryAllowedColorType>> GetAll();

        OperationResponse<PageResult<ProductAllowedColorTypePageQueryCommandOutputDTO>> PageQuery(PageQuery<ProductAllowedColorTypePageQueryCommandInputDTO> input);

        OperationResponse<DomainModel.Product.ProductCategoryAllowedColorType> GetById(int id);

        OperationResponse Insert(ProductCategoryAllowedColorType entity);

        OperationResponse Delete(ProductCategoryAllowedColorType entity);

        OperationResponse LogicalDelete(ProductCategoryAllowedColorType entity);

    }
}
