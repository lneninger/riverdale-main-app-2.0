using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(FunzaResponse<QuoteModel>))]
        public async Task<IActionResult> Get(int id)
        {
            var result = await Task.FromResult("Hello");

            return this.Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(InternalBridgeCreateQuoteOutput))]
        public async Task<IActionResult> Add(InternalBridgeCreateQuoteInput model) {
            var result = await Task.FromResult("Hello");

            return this.Ok(result);
        }

    }
}