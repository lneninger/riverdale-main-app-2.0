using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Refit;
using FunzaDirectClients.Clients.Season;
using FunzaDirectClients.InternalClients.Quote;
using FunzaDirectClients.InternalClients.Quote.Models;
using FunzaInternalClients.Quote.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/goodprices")]
    [ApiController]
    public class GoodPriceController : ControllerBase
    {
        public IGoodPriceClient GoodPriceClient { get; }

        public GoodPriceController(IGoodPriceClient goodPriceClient)
        {
            this.GoodPriceClient = goodPriceClient;
        }

        
        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<FunzaDirectAuthenticateResult>))]
        public async Task<IActionResult> Get()
        {
            await this.GoodPriceClient.SetFunzaToken(this.Request);
            var funzaResponse = await this.GoodPriceClient.GetGoodPrices();
            var funzaResult = funzaResponse.Content;

            return this.Ok(funzaResult.Result);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(InternalBridgeCreateQuoteOutput))]
        public async Task<IActionResult> MapSeason(InternalBridgeCreateQuoteInput model)
        {
            var payload = new FunzaDirectCreateQuoteInput {
                Titulo = model.Title,
                TemporadaId = model.SeasonId,
                TipoProductoId = model.ProductTypeId
            };

            await this.GoodPriceClient.SetFunzaToken(this.Request);

            return this.Ok();
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(InternalBridgeUpdateQuoteOutput))]
        public async Task<IActionResult> Update(InternalBridgeUpdateQuoteInput model)
        {
            var result = await Task.FromResult("Hello");

            return this.Ok(result);
        }

    }
}