using FunzaDirectClients.Clients;
using FunzaDirectClients.Clients.Commons;
using FunzaDirectClients.InternalClients.Quote.Models;
using Refit;
using System.Threading.Tasks;

namespace FunzaDirectClients.InternalClients.Quote
{
    public interface IQuoteClient: IRefitClient
    {
        
        [Get("/GetAll")]
        Task<ApiResponse<ApiResultWrapper<ListResult<FunzaDirectGetQuoteResult>>>> GetQuotes(int SkipCount = 0, int MaxResultCount = 10);

        [Get("/Get/{id}")]
        Task<ApiResponse<FunzaDirectAuthenticateResult>> GetQuote(int id);

        [Post("/Create")]
        Task<ApiResponse<FunzaDirectCreateQuoteResult>> CreateQuote([Body] FunzaDirectCreateQuoteInput model);

    }
}
