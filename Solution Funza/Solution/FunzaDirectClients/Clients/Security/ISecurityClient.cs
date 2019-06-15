using FunzaDirectClients.Clients.Security.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunzaDirectClients.Clients.Security
{
    public interface ISecurityClient: IRefitClient
    {
        [Post("/")]
        Task<ApiResponse<FunzaDirectAuthenticateResulWrapper>> Authenticate([Body] AuthenticationModel model);

        [Post("/")]
        Task<ApiResponse<Dictionary<string, object>>> AuthenticateDictionary([Body] AuthenticationModel model);
    }
}
