using FunzaInternalClients.Security.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunzaInternalClients.Security
{
    public interface IInternalSecurityClient
    {
        [Post("/security")]
        Task<ApiResponse<InternalBridgeAuthenticationResult>> Security([Body] InternalBridgeAuthenticationInput model);
    }
}
