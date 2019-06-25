using Framework.Refit;
using FunzaDirectClients.Clients.Commons;
using FunzaDirectClients.Clients.Sizes.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunzaDirectClients.Clients.Sizes
{
    public interface ISizeClient : IRefitClient
    {
        [Get("/")]
        Task<ApiResponse<ApiResultWrapper<ListResult<DirectGetSizesResult>>>> GetSizes(int SkipCount = 0, int MaxResultCount = 10);

    }
}
