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
        [Get("/GetAll")]
        Task<ApiResponse<ApiResultWrapper<ListResult<DirectGetProductColorsResult>>>> GetProductColors(int SkipCount = 0, int MaxResultCount = 10);

    }
}
