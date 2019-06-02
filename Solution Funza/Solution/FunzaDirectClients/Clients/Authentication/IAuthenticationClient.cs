using FunzaDirectClients.InternalClients.Quote.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunzaDirectClients.InternalClients.Quote
{
    public interface IAuthenticationClient
    {
        [Post("/")]
        Task<ApiResponse<Dictionary<string, object>>> Authenticate(string userName, string password);
    }
}
