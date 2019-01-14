using System;
using System.Collections.Generic;
using Framework.Core.Messages;
using RestSharp;

namespace FunzaRepositories
{
    public class SecurityRepository : ApplicationLogic.Repositories.Funza.ISecurityRepository
    {
        public OperationResponse<Dictionary<string, object>> Authenticate(string authenticationURL, string authenticationUserName, string authenticationPassword)
        {
            var result = new OperationResponse<Dictionary<string, object>>();

            var client = new RestClient(authenticationURL);
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", $"grant_type=password&userName={authenticationUserName}&Password={authenticationPassword}", ParameterType.RequestBody);
            // easily add HTTP Headers
            request.AddHeader("header", "value");

            var response = client.Execute<Dictionary<string, object>>(request);
            result.Bag = response.Data;

            return result;
        }
    }
}
