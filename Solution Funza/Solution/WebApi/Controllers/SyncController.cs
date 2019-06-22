using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunzaApplicationLogic.Commands.SyncCommand;
using FunzaInternalClients.Quote.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/sync")]
    [ApiController]
    public class SyncController : ControllerBase
    {

        public SyncController(IFunzaSyncCommand syncCommand)
        {
            this.FunzaSyncCommand = syncCommand;
        }

        public IFunzaSyncCommand FunzaSyncCommand { get; }


        [HttpPut()]
        [ProducesResponseType(200, Type = typeof(FunzaResponse<QuoteModel>))]
        public async Task<IActionResult> Put()
        {
            await this.FunzaSyncCommand.ExecuteAsync();
            return this.Ok();
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(InternalBridgeCreateQuoteOutput))]
        public async Task<IActionResult> Add(InternalBridgeCreateQuoteInput model) {
            var result = await Task.FromResult("Hello");

            return this.Ok(result);
        }

    }
}