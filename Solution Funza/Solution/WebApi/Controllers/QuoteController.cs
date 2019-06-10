using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunzaDirectClients.InternalClients.Quote;
using FunzaDirectClients.InternalClients.Quote.Models;
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
        public IQuoteClient QuoteClient { get; }

        public QuoteController(IQuoteClient quoteClient)
        {
            this.QuoteClient = quoteClient;
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
            var funzaResponse = await this.QuoteClient.GetQuotes();
            var result = await Task.FromResult("Hello");

            return this.Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(InternalBridgeCreateQuoteOutput))]
        public async Task<IActionResult> Add(InternalBridgeCreateQuoteInput model)
        {
            var payload = new FunzaDirectCreateQuoteInput {
                Titulo = model.Title,
            };

            var funzaResponse = (await this.QuoteClient.CreateQuote(payload)).Content;

            var result = new InternalBridgeCreateQuoteOutput
            {
                Title = funzaResponse.Titulo
            };

            return this.Ok(result);
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