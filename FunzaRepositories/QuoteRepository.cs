using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationLogic.Business.Commands.Funza.PackingPageQueryCommand.Models;
using ApplicationLogic.Business.Commands.FunzaIntegrator.GetQuotesCommand.Models;
using ApplicationLogic.Business.Commons.Funza.DTOs;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using RestSharp;

namespace FunzaRepositories
{
    public class QuoteRepository : ApplicationLogic.Repositories.Funza.IQuoteRepository
    {
        

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

        public OperationResponse<PageResult<FunzaQuoteGetItemsCommandOutputDTO>> PageQuery(PageQuery<FunzaQuoteGetItemsCommandInputDTO> input, string endpointURL, string accessToken)
        {
            var result = new OperationResponse<PageResult<FunzaQuoteGetItemsCommandOutputDTO>>();

            var client = new RestClient(endpointURL);
            var internalInput = new FunzaQuoteGetItemsCommandFunzaInputDTO
            {
                SkipCount = input.PageIndex * input.PageSize,
                MaxResultCount = input.PageSize == default(int) ? 10 : input.PageSize,
            };
            if (!string.IsNullOrWhiteSpace(input.CustomFilter.Term)) {
                internalInput.Nombre = input.CustomFilter.Term.Trim();
            }

            var request = new RestRequest(Method.GET);
            request.AddObject(internalInput);
            request.AddHeader("Authorization", $"Bearer {accessToken}");

            var response = client.Execute<FunzaPageResult<FunzaQuoteGetItemsCommandFunzaOutputDTO>>(request);

            if (response.Data != null && response.Data.Success)
            {
                result.Bag = new PageResult<FunzaQuoteGetItemsCommandOutputDTO>
                {
                    Items = response.Data.Result.Items.Select(item => new FunzaQuoteGetItemsCommandOutputDTO {
                        Title = item.Titulo
                    }).ToList()
                };
            }

            return result;
        }
    }
}
