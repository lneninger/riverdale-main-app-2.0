using FunzaDirectClients.Clients;
using FunzaDirectClients.InternalClients.Quote.Models;
using FunzaDirectClients.InternalClients.Security.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunzaDirectClients.InternalClients.Security
{
    public interface ISecurityClient: IRefitClient
    {
        [Post("/")]
        Task<ApiResponse<FunzaDirectAuthenticateResulWrapper>> Authenticate([Body] AuthenticationModel model);

        [Post("/")]
        Task<ApiResponse<Dictionary<string, object>>> AuthenticateDictionary([Body] AuthenticationModel model);
    }
}
