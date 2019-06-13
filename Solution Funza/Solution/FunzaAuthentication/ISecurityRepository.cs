using Framework.Core.Messages;
using FunzaDirectClients.InternalClients.Quote.Models;
using FunzaDirectClients.InternalClients.Security;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunzaAuthentication
{
    public interface ISecurityRepository
    {
        Task<OperationResponse<FunzaDirectAuthenticateResulWrapper>> Authenticate(string authenticationURL, string authenticationUserName, string authenticationPassword, ISecurityClient authenticationClient);
    }
}
