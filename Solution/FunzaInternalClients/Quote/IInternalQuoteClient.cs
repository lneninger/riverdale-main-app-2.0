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
        [Get("/{id}")]
        Task<ApiResponse<string>> Quote(int id);

        [Post("/quotes")]
        Task<ApiResponse<InternalBridgeCreateQuoteResult>> CreateQuote(InternalBridgeCreateQuoteInput model);
    }
}
