﻿using System;
using System.Collections.Generic;
using Framework.Core.Messages;
using RestSharp;

namespace FunzaRepositories
{
    public class SecurityRepository : ApplicationLogic.Repositories.Funza.ISecurityRepository
    {

        public OperationResponse<Dictionary<string, object>> Authenticate(string authenticationURL, string authenticationUserName, string authenticationPassword)
        {
            var result = this.AuthenticateURLEncoded(authenticationURL, authenticationUserName, authenticationPassword);
            if (!result.IsSucceed)
            {
                var resultSimplePOST = this.AuthenticateSimplePOST(authenticationURL, authenticationUserName, authenticationPassword);
                if (resultSimplePOST.IsSucceed)
                {
                    if (resultSimplePOST.Bag != null)
                    {
                        result.ClearErrors();
                        result.Bag = result.Bag ?? resultSimplePOST.Bag;
                    }
                    else
                    {
                        result.AddError("SimplePOST authentication returns NULL");
                    }
                }
                else
                {
                    result.AddResponse(resultSimplePOST);
                }

            }

            return result;
        }

        public OperationResponse<Dictionary<string, object>> AuthenticateURLEncoded(string authenticationURL, string authenticationUserName, string authenticationPassword)
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
            if (!response.IsSuccessful)
            {
                result.AddError(response.StatusCode.ToString());
                result.AddError(response.StatusDescription);
            }

            return result;
        }

        public OperationResponse<Dictionary<string, object>> AuthenticateSimplePOST(string authenticationURL, string authenticationUserName, string authenticationPassword)
        {
            var result = new OperationResponse<Dictionary<string, object>>();

            var client = new RestClient(authenticationURL);
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(new { userNameOrEmailAddress = authenticationUserName, password = authenticationPassword, rememberClient = true });
            //"application/x-www-form-urlencoded", $"grant_type=password&userName={authenticationUserName}&Password={authenticationPassword}", ParameterType.RequestBody);
            // easily add HTTP Headers
            request.AddHeader("header", "value");

            var response = client.Execute<Dictionary<string, object>>(request);
            if(response.Data != null)
            {
                result.Bag = response.Data["result"] as Dictionary<string, object>;
            }

            if (!response.IsSuccessful)
            {
                result.AddError(response.StatusCode.ToString());
                result.AddError(response.StatusDescription);
            }
            return result;
        }
    }
}
