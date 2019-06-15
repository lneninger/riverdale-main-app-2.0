using FunzaDirectClients.Clients.Commons;
using FunzaDirectClients.Clients.GoodPrice.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunzaDirectClients.Clients.GoodPrice
{
    public interface IGoodPriceClient : IRefitClient
    {
        [Get("/GetAll")]
        Task<ApiResponse<ApiResultWrapper<ListResult<DirectGetGoodPricesResult>>>> GetGoodPrices(int SkipCount = 0, int MaxResultCount = 10);

    }
}
