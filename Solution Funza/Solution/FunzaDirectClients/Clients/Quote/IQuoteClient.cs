using FunzaDirectClients.Clients;
using FunzaDirectClients.InternalClients.Quote.Models;
using Refit;
using System.Threading.Tasks;

namespace FunzaDirectClients.InternalClients.Quote
{
    public interface IQuoteClient: IRefitClient
    {
        
        [Get("/")]
        Task<ApiResponse<FunzaDirectGetQuoteResult>> GetQuotes();

        [Get("/{id}")]
        Task<ApiResponse<FunzaDirectAuthenticateResult>> GetQuote(int id);

        [Post("/Create")]
        Task<ApiResponse<FunzaDirectCreateQuoteResult>> CreateQuote([Body] FunzaDirectCreateQuoteInput model);

    }
}
