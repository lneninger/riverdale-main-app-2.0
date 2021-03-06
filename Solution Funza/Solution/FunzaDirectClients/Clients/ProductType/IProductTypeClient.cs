﻿using Framework.Refit;
using FunzaDirectClients.Clients.Commons;
using FunzaDirectClients.Clients.ProductType.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunzaDirectClients.Clients.ProductType
{
    public interface IProductTypeClient : IRefitClient
    {
        [Get("/GetAll")]
        Task<ApiResponse<ApiResultWrapper<ListResult<DirectGetProductTypesResult>>>> GetProductTypes(int SkipCount = 0, int MaxResultCount = 10);

    }
}
