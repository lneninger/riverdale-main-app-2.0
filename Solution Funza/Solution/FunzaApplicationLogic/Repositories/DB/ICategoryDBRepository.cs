using DomainModel;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using FunzaApplicationLogic.Commands.Funza.CategoryPageQueryCommand.Models;
using FunzaApplicationLogic.Repositories.DB;

namespace ApplicationLogic.Repositories.DB
{
    public interface ICategoryDBRepository : IDBRepository
    {
        OperationResponse<Category> GetById(int id);

        OperationResponse Add(Category entity);

        OperationResponse<Category> GetByFunzaId(int id);

        OperationResponse<PageResult<CategoryPageQueryCommandOutput>> PageQuery(PageQuery<CategoryPageQueryCommandInput> input);

    }
}
