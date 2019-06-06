using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunzaDirectClients.InternalClients.Quote;
using FunzaInternalClients.Quote.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels.Quote;

namespace WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/security")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public IQuoteClient QuoteClient { get; }

        public AuthenticationController(ISecurityClient securityClient)
        {
            this.SecurityClient = securityClient;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public async Task<IActionResult> Get(int id)
        {
            var result = (await this.QuoteClient.GetQuote(id)).Content;
            return this.Ok(result);
        }

        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<FunzaDirectGetQuoteResult>))]
        public async Task<IActionResult> Get()
        {
            var result = await Task.FromResult("Hello");

            return this.Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(InternalBridgeCreateQuoteResult))]
        public async Task<IActionResult> Add(InternalBridgeCreateQuoteInput model)
        {
            var result = await Task.FromResult("Hello");

            return this.Ok(result);
        }

    }
}