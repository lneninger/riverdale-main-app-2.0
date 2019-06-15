using FunzaDirectClients.Clients.Commons;
using FunzaDirectClients.InternalClients.Product.Models;
using Refit;
using System.Threading.Tasks;

namespace FunzaDirectClients.Clients.Product
{
    public interface IProductClient : IRefitClient
    {
        [Get("/GetAll")]
        Task<ApiResponse<ApiResultWrapper<ListResult<FunzaDirectGetProductsResult>>>> GetProducts(int SkipCount = 0, int MaxResultCount = 10);

    }
}
