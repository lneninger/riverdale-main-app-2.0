using Framework.Refit;
using FunzaDirectClients.Clients.Commons;
using FunzaDirectClients.Clients.Packing.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunzaDirectClients.Clients.Packing
{
    public interface IPackingClient : IRefitClient
    {
        [Get("/")]
        Task<ApiResponse<ApiResultWrapper<DirectGetPackingsResult[]>>> GetPackings(int SkipCount = 0, int MaxResultCount = 10);

    }
}
