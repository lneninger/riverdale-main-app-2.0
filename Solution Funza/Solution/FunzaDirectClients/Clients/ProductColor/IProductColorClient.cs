using Framework.Refit;
using FunzaDirectClients.Clients.Commons;
using FunzaDirectClients.Clients.ProductColor.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunzaDirectClients.Clients.ProductColor
{
    public interface IProductColorClient : IRefitClient
    {
        [Get("/")]
        Task<ApiResponse<ApiResultWrapper<DirectGetProductColorsResult[]>>> GetProductColors(int SkipCount = 0, int MaxResultCount = 10);

    }
}
