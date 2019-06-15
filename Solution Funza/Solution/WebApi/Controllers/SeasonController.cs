using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Refit;
using FunzaDirectClients.Clients.Season;
using FunzaDirectClients.InternalClients.Quote;
using FunzaDirectClients.InternalClients.Quote.Models;
using FunzaDirectClients.InternalClients.Season.Models;
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

        

        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<FunzaDirectGetSeasonsResult>))]
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
            var payload = new DirectCreateQuoteInput {
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