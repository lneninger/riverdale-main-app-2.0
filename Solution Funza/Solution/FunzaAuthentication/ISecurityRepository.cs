using Framework.Storage.DataHolders.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunzaAuthentication
{
    public interface ISecurityRepository
    {
        Task<OperationResponse<Dictionary<string, object>>> Authenticate(string authenticationURL, string authenticationUserName, string authenticationPassword);
    }
}
