using FunzaDirectClients.Clients.Price;
using FunzaDirectClients.Clients.Price.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        [ProducesResponseType(200, Type = typeof(IEnumerable<DirectGetPricesResult>))]
        public async Task<IActionResult> Get()
        {
            await this.PriceClient.SetFunzaToken(this.Request);
            var funzaResponse = await this.PriceClient.GetPrices();
            var funzaResult = funzaResponse.Content;

            return this.Ok(funzaResult.Result);
        }

    }
}