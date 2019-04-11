using ApplicationLogic.Business.Commands.Funza.ColorPageQueryCommand.Models;
using DomainModel.Funza;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;

namespace ApplicationLogic.Repositories.DB
{
    public interface IFunzaColorReferenceDBRepository: IDBRepository
    {
        OperationResponse<DomainModel.Funza.ColorReference> GetById(int id);

        OperationResponse Add(ColorReference entity);

        OperationResponse<ColorReference> GetByFunzaId(string id);

        OperationResponse<PageResult<FunzaColorPageQueryCommandOutputDTO>> PageQuery(PageQuery<FunzaColorPageQueryCommandInputDTO> input);
        
    }
}
