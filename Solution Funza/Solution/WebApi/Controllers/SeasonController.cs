using FunzaDirectClients.Clients.Season;
using FunzaDirectClients.Clients.Season.Models;
using FunzaInternalClients.Quote.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        [ProducesResponseType(200, Type = typeof(IEnumerable<DirectGetSeasonsResult>))]
        public async Task<IActionResult> Get()
        {
            await this.SeasonClient.SetFunzaToken(this.Request);
            var funzaResponse = await this.SeasonClient.GetSeasons();
            var result = await Task.FromResult("Hello");

            return this.Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(InternalBridgeCreateQuoteOutput))]
        public async Task<IActionResult> MapSeason(InternalBridgeCreateQuoteInput model, [FromServices] ISeasonMapCommand seasonMapCommand)
        {
            var payload = new DirectCreateQuoteInput {
                Titulo = model.Title,
                TemporadaId = model.SeasonId,
                TipoProductoId = model.ProductTypeId
            };

            await this.SeasonClient.SetFunzaToken(this.Request);

            return this.Ok();
        }


    }
}