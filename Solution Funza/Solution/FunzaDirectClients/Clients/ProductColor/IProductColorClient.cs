using FunzaDirectClients.Clients.Commons;
using FunzaDirectClients.InternalClients.ProductColor.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunzaDirectClients.Clients.ProductColor
{
    public interface IProductColorClient : IRefitClient
    {
        [Get("/GetAll")]
        Task<ApiResponse<ApiResultWrapper<ListResult<FunzaDirectGetProductColorsResult>>>> GetProductColors(int SkipCount = 0, int MaxResultCount = 10);

    }
}
