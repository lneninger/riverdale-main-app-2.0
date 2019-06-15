using FunzaDirectClients.Clients.Commons;
using FunzaDirectClients.Clients.Quote.Models;
using Refit;
using System.Threading.Tasks;

namespace FunzaDirectClients.Clients.Quote
{
    public interface IQuoteClient: IRefitClient
    {
        
        [Get("/GetAll")]
        Task<ApiResponse<ApiResultWrapper<ListResult<FunzaDirectGetQuoteResult>>>> GetQuotes(int SkipCount = 0, int MaxResultCount = 10);

        [Post("/Create")]
        Task<ApiResponse<FunzaDirectCreateQuoteResult>> CreateQuote([Body] FunzaDirectCreateQuoteInput model);


        [Get("/Get/{id}")]
        Task<ApiResponse<FunzaDirectGetQuoteResult>> GetQuote(int id);
    }
}
