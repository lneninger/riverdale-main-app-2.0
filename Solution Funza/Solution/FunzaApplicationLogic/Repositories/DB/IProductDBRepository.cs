using DomainModel;
using DomainModel.Funza;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using FunzaApplicationLogic.Commands.Funza.ProductPageQueryCommand.Models;
using FunzaApplicationLogic.Repositories.DB;

namespace ApplicationLogic.Repositories.DB
{
    public interface IProductDBRepository: IDBRepository
    {
        OperationResponse<Product> GetById(int id);

        OperationResponse Add(Product entity);

        OperationResponse<Product> GetByFunzaId(int id);

        OperationResponse<PageResult<ProductPageQueryCommandOutput>> PageQuery(PageQuery<ProductPageQueryCommandInput> input);
    }
}
