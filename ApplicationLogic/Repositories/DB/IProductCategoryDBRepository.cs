using ApplicationLogic.Business.Commands.ProductCategory.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.ProductCategory.PageQueryCommand.Models;
using DomainModel.Product;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Repositories.DB
{
    public interface IProductCategoryDBRepository : IDBRepository
    {
        OperationResponse<IEnumerable<ProductCategory>> GetAll();

        OperationResponse<PageResult<ProductCategoryPageQueryCommandOutputDTO>> PageQuery(PageQuery<ProductCategoryPageQueryCommandInputDTO> input);

        OperationResponse<DomainModel.Product.ProductCategory> GetById(string id);

        
        OperationResponse Insert(ProductCategory entity);

        OperationResponse Delete(ProductCategory entity);

        OperationResponse<ProductCategoryDeleteCommandOutputDTO> LogicalDelete(ProductCategory entity);

    }
}
