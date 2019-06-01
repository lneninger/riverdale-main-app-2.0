﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunzaInternalClients.Quote.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(InternalBridgeCreateQuoteResult))]
        public Task<IActionResult> Add(InternalBridgeCreateQuoteInput model) {

        }

    }
}