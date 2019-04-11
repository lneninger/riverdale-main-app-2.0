using ApplicationLogic.Business.Commands.ProductAllowedColorType.PageQueryCommand.Models;
using DomainModel.Product;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Repositories.DB
{
    public interface IProductAllowedColorTypeDBRepository: IDBRepository
    {
        OperationResponse<IEnumerable<ProductAllowedColorType>> GetAll();

        OperationResponse<PageResult<ProductAllowedColorTypePageQueryCommandOutputDTO>> PageQuery(PageQuery<ProductAllowedColorTypePageQueryCommandInputDTO> input);

        OperationResponse<DomainModel.Product.ProductAllowedColorType> GetById(int id);

        OperationResponse Insert(ProductAllowedColorType entity);

        OperationResponse Delete(ProductAllowedColorType entity);

        OperationResponse LogicalDelete(ProductAllowedColorType entity);

    }
}
