using System;
using System.Collections.Generic;
using ApplicationLogic.Business.Commands.FunzaIntegrator.GetProductsCommand.Models;
using Framework.Core.Messages;
using RestSharp;

namespace FunzaRepositories
{
    public class MastersRepository : ApplicationLogic.Repositories.Funza.IMastersRepository
    {
        public OperationResponse<IEnumerable<FunzaGetProductsCommandOutputDTO>> GetProducts(string authenticationURL, string accessToken)
        {
            var result = new OperationResponse<IEnumerable<FunzaGetProductsCommandOutputDTO>>();

            var client = new RestClient(authenticationURL);

            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {accessToken}");

            var response = client.Execute<List<FunzaGetProductsCommandOutputDTO>>(request);
            result.Bag = response.Data;

            return result;
        }
    }
}
