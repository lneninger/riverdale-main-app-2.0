using FunzaDirectClients.InternalClients.Quote.Models;
using Refit;
using System.Threading.Tasks;

namespace FunzaDirectClients.InternalClients.Quote
{
    public interface IQuoteClient
    {
        
        [Get("/")]
        Task<ApiResponse<FunzaDirectGetQuoteResult>> GetQuotes();

        [Get("/{id}")]
        Task<ApiResponse<FunzaDirectGetQuoteResult>> GetQuote(int id);

        [Post("/")]
        Task<ApiResponse<FunzaDirectCreateQuoteResult>> CreateQuote([Body] FunzaDirectCreateQuoteInput model);

    }
}
