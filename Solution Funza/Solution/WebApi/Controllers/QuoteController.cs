using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunzaInternalClients.Quote.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/quotes")]
    [ApiController]
    public class QuoteController : ControllerBase
    {

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public async Task<IActionResult> Get(int id)
        {
            var result = await Task.FromResult("Hello");

            return this.Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(InternalBridgeCreateQuoteResult))]
        public async Task<IActionResult> Add(InternalBridgeCreateQuoteInput model) {
            var result = await Task.FromResult("Hello");

            return this.Ok(result);
        }

    }
}