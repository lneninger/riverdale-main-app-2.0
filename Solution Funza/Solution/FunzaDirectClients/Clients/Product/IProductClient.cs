using FunzaDirectClients.Clients.Commons;
using FunzaDirectClients.Clients.Product.Models;
using Refit;
using System.Threading.Tasks;

namespace FunzaDirectClients.Clients.Product
{
    public interface IProductClient : IRefitClient
    {
        [Get("/GetAll")]
        Task<ApiResponse<ApiResultWrapper<ListResult<DirectGetProductsResult>>>> GetProducts(int SkipCount = 0, int MaxResultCount = 10);

    }
}
