using Framework.Refit;
using FunzaDirectClients.Clients.Commons;
using FunzaDirectClients.Clients.Price.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunzaDirectClients.Clients.Price
{
    public interface IPriceClient : IRefitClient
    {
        [Get("/GetAll")]
        Task<ApiResponse<ApiResultWrapper<ListResult<DirectGetPricesResult>>>> GetPrices(int SkipCount = 0, int MaxResultCount = 10);

    }
}
