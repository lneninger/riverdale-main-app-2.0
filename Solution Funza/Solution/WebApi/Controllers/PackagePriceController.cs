using FunzaDirectClients.Clients.PackagePrice;
using FunzaDirectClients.Clients.PackagePrice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/packageprices")]
    [ApiController]
    public class PackagePriceController : ControllerBase
    {
        public IPackagePriceClient PackagePriceClient { get; }

        public PackagePriceController(IPackagePriceClient packagePriceClient)
        {
            this.PackagePriceClient = packagePriceClient;
        }

        
        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DirectGetPackagePricesResult>))]
        public async Task<IActionResult> Get()
        {
            await this.PackagePriceClient.SetFunzaToken(this.Request);
            var funzaResponse = await this.PackagePriceClient.GetPackagePrices();
            var funzaResult = funzaResponse.Content;

            return this.Ok(funzaResult.Result);
        }

    }
}