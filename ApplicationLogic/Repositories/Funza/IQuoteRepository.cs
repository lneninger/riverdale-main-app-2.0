using DomainModel;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core.Messages;
using ApplicationLogic.Business.Commands.Funza.CategoryPageQueryCommand.Models;
using ApplicationLogic.Business.Commands.Funza.PackingPageQueryCommand.Models;
using System.Threading.Tasks;
using DomainModel.Product;
using FunzaInternalClients.Quote.Models;

namespace ApplicationLogic.Repositories.Funza
{
    public interface IQuoteRepository
    {
        Task<OperationResponse<InternalBridgeCreateQuoteOutput>> Upsert(AbstractProduct input);

        OperationResponse<PageResult<FunzaQuoteGetItemsCommandOutputDTO>> PageQuery(PageQuery<FunzaQuoteGetItemsCommandInputDTO> input, string endpointURL, string accessToken);

    }
}
