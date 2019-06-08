using FunzaInternalClients.Quote.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunzaInternalClients.Quote
{
    public interface IInternalQuoteClient
    {
        [Get("/")]
        Task<ApiResponse<IEnumerable<InternalBridgeQuoteOutput>>> GetQuotes(int id);

        [Get("/{id}")]
        Task<ApiResponse<InternalBridgeQuoteOutput>> GetQuote(int id);

        [Post("/")]
        Task<ApiResponse<InternalBridgeCreateQuoteResult>> CreateQuote(InternalBridgeCreateQuoteInput model);
    }
}
