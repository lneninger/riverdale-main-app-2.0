using System;
using System.Collections.Generic;
using ApplicationLogic.Business.Commands.FunzaIntegrator.GetCategoriesCommand.Models;
using ApplicationLogic.Business.Commands.FunzaIntegrator.GetColorsCommand.Models;
using ApplicationLogic.Business.Commands.FunzaIntegrator.GetPackingsCommand.Models;
using ApplicationLogic.Business.Commands.FunzaIntegrator.GetProductsCommand.Models;
using ApplicationLogic.Business.Commands.FunzaIntegrator.GetQuotesCommand.Models;
using Framework.Core.Messages;
using RestSharp;

namespace FunzaRepositories
{
    public class MastersRepository : ApplicationLogic.Repositories.Funza.IMastersRepository
    {
        public OperationResponse<IEnumerable<FunzaGetColorsCommandOutputDTO>> GetColors(string getColorsURL, string accessToken)
        {
            var result = new OperationResponse<IEnumerable<FunzaGetColorsCommandOutputDTO>>();

            var client = new RestClient(getColorsURL);

            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {accessToken}");

            var response = client.Execute<List<FunzaGetColorsCommandOutputDTO>>(request);
            result.Bag = response.Data;

            return result;
        }

        public OperationResponse<IEnumerable<FunzaGetProductsCommandOutputDTO>> GetProducts(string endpointURL, string accessToken)
        {
            var result = new OperationResponse<IEnumerable<FunzaGetProductsCommandOutputDTO>>();

            var client = new RestClient(endpointURL);

            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {accessToken}");

            var response = client.Execute<List<FunzaGetProductsCommandOutputDTO>>(request);
            result.Bag = response.Data;

            return result;
        }

        public OperationResponse<IEnumerable<FunzaGetCategoriesCommandOutputDTO>> GetCategories(string endpointURL, string accessToken)
        {
            var result = new OperationResponse<IEnumerable<FunzaGetCategoriesCommandOutputDTO>>();

            var client = new RestClient(endpointURL);

            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {accessToken}");

            var response = client.Execute<List<FunzaGetCategoriesCommandOutputDTO>>(request);
            result.Bag = response.Data;

            return result;
        }

        public OperationResponse<IEnumerable<FunzaGetPackingsCommandOutputDTO>> GetPackings(string endpointURL, string accessToken)
        {
            var result = new OperationResponse<IEnumerable<FunzaGetPackingsCommandOutputDTO>>();

            var client = new RestClient(endpointURL);

            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {accessToken}");

            var response = client.Execute<List<FunzaGetPackingsCommandOutputDTO>>(request);
            result.Bag = response.Data;

            return result;
        }

        public OperationResponse<IEnumerable<FunzaGetQuotesCommandOutputDTO>> GetQuotes(string endpointURL, string accessToken)
        {
            var result = new OperationResponse<IEnumerable<FunzaGetQuotesCommandOutputDTO>>();

            var client = new RestClient(endpointURL);

            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {accessToken}");

            var response = client.Execute<List<FunzaGetQuotesCommandOutputDTO>>(request);
            result.Bag = response.Data;

            return result;
        }
    }
}
