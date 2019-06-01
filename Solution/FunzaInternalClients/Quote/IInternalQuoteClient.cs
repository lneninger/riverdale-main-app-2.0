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
        [Post("/quotes")]
        Task<ApiResponse<InternalBridgeCreateQuoteResult>> CreateQuote(InternalBridgeCreateQuoteInput model);
    }
}
