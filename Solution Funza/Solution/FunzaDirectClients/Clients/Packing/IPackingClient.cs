using FunzaDirectClients.Clients.Commons;
using FunzaDirectClients.InternalClients.GoodSeason.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunzaDirectClients.Clients.PackagePrice
{
    public interface IPackingClient : IRefitClient
    {
        [Get("/GetAll")]
        Task<ApiResponse<ApiResultWrapper<ListResult<FunzaDirectGetPackingsResult>>>> GetPackings(int SkipCount = 0, int MaxResultCount = 10);

    }
}
