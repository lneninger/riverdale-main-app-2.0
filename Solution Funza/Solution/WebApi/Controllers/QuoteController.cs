using Framework.Refit;
using FunzaApplicationLogic.Commands.Funza.QuoteUpsertCommand;
using FunzaApplicationLogic.Commands.Funza.QuoteUpsertCommand.Models;
using FunzaDirectClients.Clients.Commons;
using FunzaDirectClients.Clients.Quote;
using FunzaDirectClients.Clients.Quote.Models;
using FunzaInternalClients.Quote.Models;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/quotes")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        public IQuoteClient QuoteClient { get; }
        public IQuoteUpsertCommand QuoteUpsertCommand { get; }

        public QuoteController(IQuoteClient quoteClient, IQuoteUpsertCommand upsertCommand)
        {
            this.QuoteClient = quoteClient;
            this.QuoteUpsertCommand = upsertCommand;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public async Task<IActionResult> Get(int id)
        {
            var quoteClient = RefitExtensions.InstanciateClient<IQuoteClient>(RefitConfig.GetHttpClient());

            var result = (await quoteClient.GetQuote(id)).Content;
            //var result = (await this.QuoteClient.GetQuote(id)).Content;
            return this.Ok(result);
        }

        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(ListResult<FunzaDirectGetQuoteResult>))]
        public async Task<IActionResult> Get()
        {
            await this.QuoteClient.SetFunzaToken(this.Request);

            ApiResponse<ApiResultWrapper<ListResult<FunzaDirectGetQuoteResult>>> funzaResponse = null;

            try
            {
                funzaResponse = await this.QuoteClient.GetQuotes();
            }
            catch (Exception ex)
            {
                throw;
            }

            //var funzaResponse = await this.QuoteClient.GetQuotes();
            var result = await Task.FromResult("Hello");

            return this.Ok(funzaResponse.Content.Result);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(InternalBridgeCreateQuoteOutput))]
        public async Task<IActionResult> Add(InternalBridgeCreateQuoteInput model)
        {
            var payload = new FunzaDirectCreateQuoteInput {
                Titulo = model.Title,
                TemporadaId = model.SeasonId,
                TipoProductoId = model.ProductTypeId
            };

            await this.QuoteClient.SetFunzaToken(this.Request);

            //var quoteClient = RestService.For<IQuoteClient>(RefitConfig.GetHttpClient());

            //var funzaResponse = await quoteClient.CreateQuote(payload);
            var funzaResponse = await this.QuoteClient.CreateQuote(payload);
            var funzaResult = funzaResponse.Content;

            var result = new InternalBridgeCreateQuoteOutput
            {
                Title = funzaResult.Titulo
            };

            return this.Ok(result);
        }


        [HttpPost("upsert")]
        [ProducesResponseType(200, Type = typeof(InternalBridgeCreateQuoteOutput))]
        public IActionResult Upsert(InternalBridgeCreateQuoteInput model, [FromServices] IQuoteUpsertCommand quoteUpsertCommand)
        {

            var payload = QuoteUpsertCommandInput.Map(model);

            var result = quoteUpsertCommand.Execute(payload);

            return this.Ok(result);
        }


    }
}