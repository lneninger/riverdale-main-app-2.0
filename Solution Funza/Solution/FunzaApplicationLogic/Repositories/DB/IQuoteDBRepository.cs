using DomainModel;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using FunzaApplicationLogic.Commands.Funza.QuotePageQueryCommand.Models;
using FunzaApplicationLogic.Commands.Funza.QuoteUpsertCommand.Models;
using FunzaApplicationLogic.Repositories.DB;

namespace ApplicationLogic.Repositories.DB
{
    public interface IQuoteDBRepository: IDBRepository
    {
        OperationResponse<Quote> GetById(int id);

        OperationResponse Add(Quote entity);

        OperationResponse<Quote> GetByFunzaId(int id);

        OperationResponse<PageResult<QuotePageQueryCommandOutput>> PageQuery(PageQuery<QuotePageQueryCommandInput> input);
        OperationResponse<PageResult<QuoteUpsertCommandOutput>> GetByInternalId(object internalId);
    }
}
