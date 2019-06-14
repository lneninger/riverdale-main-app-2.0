using FunzaDirectClients.Clients;
using FunzaDirectClients.Clients.Commons;
using FunzaDirectClients.InternalClients.SubClient.Models;
using Refit;
using System.Threading.Tasks;

namespace FunzaDirectClients.InternalClients.SubClient
{
    public interface ISubClientClient: IRefitClient
    {
        
        [Get("/GetAll")]
        Task<ApiResponse<ApiResultWrapper<ListResult<FunzaDirectGetSubClientsResult>>>> GetSubClients(int SkipCount = 0, int MaxResultCount = 10);
    }
}
