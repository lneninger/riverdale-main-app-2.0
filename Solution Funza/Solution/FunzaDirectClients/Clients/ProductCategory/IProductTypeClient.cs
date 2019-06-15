using FunzaDirectClients.Clients.Commons;
using FunzaDirectClients.Clients.ProductCategory.Models;
using Refit;
using System.Threading.Tasks;

namespace FunzaDirectClients.Clients.ProductCategory
{
    public interface IProductCategoryClient : IRefitClient
    {
        [Get("/GetAll")]
        Task<ApiResponse<ApiResultWrapper<ListResult<DirectGetProductCategoriesResult>>>> GetProductCategories(int SkipCount = 0, int MaxResultCount = 10);

    }
}
