using ApplicationLogic.Business.Commands.Product.PageQueryCommand.Models;
using DomainModel.Product;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System.Collections.Generic;

namespace ApplicationLogic.Repositories.DB
{
    public interface IProductDBRepository: IDBRepository
    {
        OperationResponse<IEnumerable<AbstractProduct>> GetAll();

        OperationResponse<PageResult<ProductPageQueryCommandOutputDTO>> PageQuery(PageQuery<ProductPageQueryCommandInputDTO> input);

        OperationResponse<DomainModel.Product.AbstractProduct> GetById(int id);

        OperationResponse<DomainModel.Product.AbstractProduct> GetByIdWithMedias(int id);

        OperationResponse Insert(AbstractProduct entity);

        OperationResponse Delete(AbstractProduct entity);

        OperationResponse LogicalDelete(AbstractProduct entity);

    }
}
