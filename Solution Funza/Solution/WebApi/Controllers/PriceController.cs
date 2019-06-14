using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Refit;
using FunzaDirectClients.Clients.PackagePrice;
using FunzaDirectClients.Clients.Price;
using FunzaDirectClients.Clients.Season;
using FunzaDirectClients.InternalClients.GoodSeason.Models;
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
    [Route("api/v{version:apiVersion}/prices")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        public IPriceClient PriceClient { get; }

        public PriceController(IPriceClient priceClient)
        {
            this.PriceClient = priceClient;
        }

        
        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<FunzaDirectGetPackagePricesResult>))]
        public async Task<IActionResult> Get()
        {
            await this.PriceClient.SetFunzaToken(this.Request);
            var funzaResponse = await this.PriceClient.GetPrices();
            var funzaResult = funzaResponse.Content;

            return this.Ok(funzaResult.Result);
        }

    }
}