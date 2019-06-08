using Framework.Core.Messages;
using FunzaDirectClients.InternalClients.Security;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunzaAuthentication
{
    public interface ISecurityRepository
    {
        Task<OperationResponse<Dictionary<string, object>>> Authenticate(string authenticationURL, string authenticationUserName, string authenticationPassword, ISecurityClient authenticationClient);
    }
}
