using ApplicationLogic.Business.Commands.Funza.QuotePageQueryCommand.Models;
using DomainModel.Funza;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;

namespace ApplicationLogic.Repositories.DB
{
    public interface IFunzaQuoteReferenceDBRepository: IDBRepository
    {
        OperationResponse<DomainModel.Funza.QuoteReference> GetById(int id);

        OperationResponse Add(QuoteReference entity);

        OperationResponse<QuoteReference> GetByFunzaId(int id);

        OperationResponse<PageResult<FunzaQuotePageQueryCommandOutputDTO>> PageQuery(PageQuery<FunzaQuotePageQueryCommandInputDTO> input);
    }
}
