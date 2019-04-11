using ApplicationLogic.Business.Commands.FlowerProductCategory.PageQueryCommand.Models;
using DomainModel.Product;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Repositories.DB
{
    public interface IFlowerProductCategoryDBRepository : IDBRepository
    {
        OperationResponse<IEnumerable<FlowerProductCategory>> GetAll();

        OperationResponse<PageResult<FlowerProductCategoryPageQueryCommandOutputDTO>> PageQuery(PageQuery<FlowerProductCategoryPageQueryCommandInputDTO> input);

        OperationResponse<DomainModel.Product.FlowerProductCategory> GetById(string id);

        
        OperationResponse Insert(FlowerProductCategory entity);

        OperationResponse Delete(FlowerProductCategory entity);

        OperationResponse LogicalDelete(FlowerProductCategory entity);

    }
}
