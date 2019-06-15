using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Refit;
using FunzaDirectClients.Clients.GoodPrice;
using FunzaDirectClients.Clients.Season;
using FunzaDirectClients.Clients.GoodPrice.Models;
using FunzaDirectClients.Clients.Season.Models;
using FunzaDirectClients.Clients.Quote;
using FunzaDirectClients.Clients.Quote.Models;
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
        [ProducesResponseType(200, Type = typeof(IEnumerable<FunzaDirectGetGoodPricesResult>))]
        public async Task<IActionResult> Get()
        {
            await this.GoodPriceClient.SetFunzaToken(this.Request);
            var funzaResponse = await this.GoodPriceClient.GetGoodPrices();
            var funzaResult = funzaResponse.Content;

            return this.Ok(funzaResult.Result);
        }

    }
}