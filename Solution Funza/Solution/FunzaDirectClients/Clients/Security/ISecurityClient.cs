using FunzaDirectClients.InternalClients.Quote.Models;
using FunzaDirectClients.InternalClients.Security.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunzaDirectClients.InternalClients.Security
{
    public interface ISecurityClient
    {
        [Post("/")]
        Task<ApiResponse<Dictionary<string, object>>> Authenticate([Body] AuthenticationModel model);
    }
}
