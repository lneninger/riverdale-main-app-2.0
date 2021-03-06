﻿using Framework.Refit;
using FunzaDirectClients.Clients.Commons;
using FunzaDirectClients.Clients.ProductCategory.Models;
using Refit;
using System.Threading.Tasks;

namespace FunzaDirectClients.Clients.ProductCategory
{
    public interface IProductCategoryClient : IRefitClient
    {
        [Get("/")]
        Task<ApiResponse<ApiResultWrapper<DirectGetProductCategoriesResult[]>>> GetProductCategories(int SkipCount = 0, int MaxResultCount = 10);

    }
}
