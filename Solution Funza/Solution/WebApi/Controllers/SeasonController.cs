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
    [Route("api/v{version:apiVersion}/seasons")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        public ISeasonClient SeasonClient { get; }

        public SeasonController(ISeasonClient seasonClient)
        {
            this.SeasonClient = seasonClient;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public async Task<IActionResult> Get(int id)
        {
            var quoteClient = RefitExtensions.InstanciateClient<IQuoteClient>(RefitConfig.GetHttpClient());

            var result = (await quoteClient.GetQuote(id)).Content;
            //var result = (await this.QuoteClient.GetQuote(id)).Content;
            return this.Ok(result);
        }

        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<FunzaDirectAuthenticateResult>))]
        public async Task<IActionResult> Get()
        {
            await this.SeasonClient.SetFunzaToken(this.Request);
            var funzaResponse = await this.SeasonClient.GetSeasons();
            var result = await Task.FromResult("Hello");

            return this.Ok(result);
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

            await this.SeasonClient.SetFunzaToken(this.Request);

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