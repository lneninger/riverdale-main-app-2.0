using Framework.Refit;
using FunzaDirectClients.Clients.Commons;
using FunzaDirectClients.Clients.PackagePrice.Models;
using Refit;
using System.Threading.Tasks;

namespace FunzaDirectClients.Clients.PackagePrice
{
    public interface IPackagePriceClient : IRefitClient
    {
        [Get("/GetAll")]
        Task<ApiResponse<ApiResultWrapper<ListResult<DirectGetPackagePricesResult>>>> GetPackagePrices(int SkipCount = 0, int MaxResultCount = 10);

    }
}
