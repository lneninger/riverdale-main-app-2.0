using FunzaDirectClients.Clients.Commons;
using FunzaDirectClients.Clients.CompositionType.Models;
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
        Task<ApiResponse<ApiResultWrapper<ListResult<DirectGetCompositionTypesResult>>>> GetPackagePrices(int SkipCount = 0, int MaxResultCount = 10);

    }
}
