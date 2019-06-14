using FunzaDirectClients.Clients.Commons;
using FunzaDirectClients.InternalClients.CompositionType.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunzaDirectClients.Clients.CompositionType
{
    public interface ICompositionTypeClient : IRefitClient
    {
        [Get("/GetAll")]
        Task<ApiResponse<ApiResultWrapper<ListResult<FunzaDirectGetCompositionTypesResult>>>> GetPackagePrices(int SkipCount = 0, int MaxResultCount = 10);

    }
}
