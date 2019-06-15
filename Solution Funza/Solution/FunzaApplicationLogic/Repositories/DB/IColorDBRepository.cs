using DomainModel;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using FunzaApplicationLogic.Repositories.DB;

namespace ApplicationLogic.Repositories.DB
{
    public interface IColorDBRepository: IDBRepository
    {
        OperationResponse<DomainModel.Color> GetById(int id);

        OperationResponse Add(Color entity);

        OperationResponse<Color> GetByFunzaId(string id);

        OperationResponse<PageResult<ColorPageQueryCommandOutput>> PageQuery(PageQuery<ColorPageQueryCommandInput> input);
        
    }
}
