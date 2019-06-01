using FunzaDirectClients.InternalClients.Quote.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunzaDirectClients.InternalClients.Quote
{
    public interface IQuoteClient
    {
        [Post("/quotes")]
        Task<ApiResponse<FunzaDirectCreateQuoteResult>> CreateQuote(FunzaDirectCreateQuoteInput model);
    }
}
