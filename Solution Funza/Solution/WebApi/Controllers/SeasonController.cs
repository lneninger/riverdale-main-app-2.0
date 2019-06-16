using FunzaApplicationLogic.Commands.Funza.Season.SeasonCommand;
using FunzaApplicationLogic.Commands.Funza.Season.SeasonMapCommand.Models;
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
        public ISeasonMapCommand SeasonMapCommand { get; }

        public SeasonController(ISeasonClient seasonClient, ISeasonMapCommand seasonMapCommand)
        {
            this.SeasonClient = seasonClient;
            this.SeasonMapCommand = seasonMapCommand;
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
        public IActionResult MapSeason(InternalBridgeCreateQuoteInput model, [FromServices] ISeasonMapCommand seasonMapCommand)
        {
            var input = new SeasonMapCommandInput {
            };

            var result = this.SeasonMapCommand.Execute(input);

            return this.Ok(result);
        }


    }
}